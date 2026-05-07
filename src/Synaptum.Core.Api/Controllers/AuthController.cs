using System.Runtime.Versioning;
using Microsoft.AspNetCore.Mvc;
using Synaptum.Core.Application.Interfaces;

namespace Synaptum.Core.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string email, string password)
        {
            var user = await _authService.Register(email, password);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var token = await _authService.Login(email, password);
            return Ok(new { token });
        }
    }
}