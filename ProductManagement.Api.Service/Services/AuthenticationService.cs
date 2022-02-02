using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProductManagement.Api.Data.Interface;
using ProductManagement.Api.Data.Models;
using ProductManagement.Api.Model;
using ProductManagement.Api.Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductManagement.Api.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public AuthenticationService(IUserRepository userRepository, IMapper mapper, IOptions<AppSettings> appSettings)
        { 
            _userRepository = userRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public async Task<AuthenticationResponse> AutenticateUser(AuthenticationDetails authDetails)
        {
            var userInfo = await _userRepository.Find(x => x.Email.Equals(authDetails.UserName) && x.Password.Equals(authDetails.Password));

            var userDetails = _mapper.Map<User, UserDetails>(userInfo);

            // return null if user not found
            if (userInfo == null) return null;

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(userDetails);

            return new AuthenticationResponse(userDetails, token);
        }

        public async Task<UserDetails> GetById(int userId)
        {
            var result = await _userRepository.GetById(userId);
            return _mapper.Map<User, UserDetails>(result);
        }

        private string GenerateJwtToken(UserDetails userDetails)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", userDetails.UserId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
