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

            // Save refresh token in database
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
    }
}