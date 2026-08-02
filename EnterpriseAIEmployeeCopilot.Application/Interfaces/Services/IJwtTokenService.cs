using EnterpriseAIEmployeeCopilot.Application.DTOs.Auth;
using EnterpriseAIEmployeeCopilot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAIEmployeeCopilot.Application.Interfaces.Services
{
    public interface IJwtTokenService
    {
        LoginResponseDto GenerateToken(Employee employee);

        string GenerateRefreshToken();
    }
}
