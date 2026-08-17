using EnterpriseAIEmployeeCopilot.Application.DTOs.Auth;

namespace EnterpriseAIEmployeeCopilot.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto dto);

        Task<LoginResponseDto> RefreshTokenAsync(
           RefreshTokenRequestDto dto);

        Task LogoutAsync(
            RefreshTokenRequestDto dto);
    }
}