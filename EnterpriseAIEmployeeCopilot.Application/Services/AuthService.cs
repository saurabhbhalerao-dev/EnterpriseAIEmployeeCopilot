using EnterpriseAIEmployeeCopilot.Application.DTOs.Auth;
using EnterpriseAIEmployeeCopilot.Application.Interfaces.Services;
using EnterpriseAIEmployeeCopilot.Domain.Entities;
using EnterpriseAIEmployeeCopilot.Domain.Interfaces;

namespace EnterpriseAIEmployeeCopilot.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthService(
            IUnitOfWork unitOfWork,
            IJwtTokenService jwtTokenService)
        {
            _unitOfWork = unitOfWork;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto dto)
        {
            var employee = await _unitOfWork.Employees
                .GetByEmailAsync(dto.Email);

            if (employee == null)
                throw new Exception("Invalid email or password.");

            if (!BCrypt.Net.BCrypt.Verify(
                    dto.Password,
                    employee.PasswordHash))
            {
                throw new Exception("Invalid email or password.");
            }

            var response = _jwtTokenService.GenerateToken(employee);

            var refreshToken = new RefreshToken
            {
                EmployeeId = employee.Id,
                Token = response.RefreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                IsRevoked = false
            };

            await _unitOfWork.RefreshTokens.AddAsync(refreshToken);

            await _unitOfWork.SaveChangesAsync();

            return response;
        }

        public async Task<LoginResponseDto> RefreshTokenAsync(
            RefreshTokenRequestDto dto)
        {
            var refreshTokens = await _unitOfWork.RefreshTokens
                .FindAsync(x =>
                    x.Token == dto.RefreshToken &&
                    !x.IsRevoked);

            var refreshToken = refreshTokens.FirstOrDefault();

            if (refreshToken == null)
                throw new Exception("Invalid refresh token.");

            if (refreshToken.ExpiryDate <= DateTime.UtcNow)
                throw new Exception("Refresh token has expired.");

            var employee = await _unitOfWork.Employees
                .GetByIdAsync(refreshToken.EmployeeId);

            if (employee == null)
                throw new Exception("Employee not found.");

            var response = _jwtTokenService.GenerateToken(employee);

            // Revoke old refresh token
            refreshToken.IsRevoked = true;

            // Store new refresh token
            var newRefreshToken = new RefreshToken
            {
                EmployeeId = employee.Id,
                Token = response.RefreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                IsRevoked = false
            };

            await _unitOfWork.RefreshTokens.AddAsync(newRefreshToken);

            await _unitOfWork.SaveChangesAsync();

            return response;
        }

        public async Task LogoutAsync(
    RefreshTokenRequestDto dto)
        {
            var refreshTokens = await _unitOfWork.RefreshTokens
                .FindAsync(x =>
                    x.Token == dto.RefreshToken &&
                    !x.IsRevoked);

            var refreshToken = refreshTokens.FirstOrDefault();

            if (refreshToken == null)
                throw new Exception("Invalid or already revoked refresh token.");

            refreshToken.IsRevoked = true;

            await _unitOfWork.SaveChangesAsync();
        }
    }
}