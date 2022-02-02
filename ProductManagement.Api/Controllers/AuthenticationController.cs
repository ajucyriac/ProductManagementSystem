using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Api.Model;
using ProductManagement.Api.Service.Interface;

namespace ProductManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        /// <summary>
        /// Api to generate token for the authenticated user 
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        [HttpPost("token")]
        public async Task<ActionResult<AuthenticationResponse>> GenerateToken(AuthenticationDetails authenticationDetails)
        {
            var response = await _authenticationService.AutenticateUser(authenticationDetails);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}
