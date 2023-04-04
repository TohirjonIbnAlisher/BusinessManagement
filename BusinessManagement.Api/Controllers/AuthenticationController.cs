using BusinessManagement.Application.EntitiesDto.AuthenticationDtos;
using BusinessManagement.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusinessManagement.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(
            IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost("Login")]
        public async ValueTask<IActionResult> LoginAsync(LoginDto loginDto)
        {
            var authenticationDto = this.authenticationService
                .LoginAsync(loginDto);

            return Ok(authenticationDto);
        }

        [HttpPost("RefreshToken")]
        public async ValueTask<IActionResult> RefreshTokenAsync(
            RefreshTokenDto refreshTokenDto)
        {
            var token = this.authenticationService
                .RefreshTokenAsync(refreshTokenDto);

            return Ok(token);
        }
    }
}
