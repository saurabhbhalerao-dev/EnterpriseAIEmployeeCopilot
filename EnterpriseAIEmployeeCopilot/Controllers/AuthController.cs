using EnterpriseAIEmployeeCopilot.Application.DTOs.Auth;
using EnterpriseAIEmployeeCopilot.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAIEmployeeCopilot.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginRequestDto request)
        {
            var result = await _authService.LoginAsync(request);

            return Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<LoginResponseDto>> Refresh(
           RefreshTokenRequestDto request)
        {
            var result = await _authService.RefreshTokenAsync(request);

            return Ok(result);
        }
    }
}