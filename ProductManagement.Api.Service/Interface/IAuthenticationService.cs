using ProductManagement.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Api.Service.Interface
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AutenticateUser(AuthenticationDetails authDetails);
        Task<UserDetails> GetById(int userId);

        Task<UserDetails> Register(RegisterRequest userInfo);
    }
}
