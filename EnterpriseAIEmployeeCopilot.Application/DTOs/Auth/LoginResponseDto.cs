using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAIEmployeeCopilot.Application.DTOs.Auth
{
    public class LoginResponseDto
    {
        public string AccessToken { get; set; } = string.Empty;

        public string RefreshToken { get; set; } = string.Empty;

        public DateTime Expiration { get; set; }
    }
}
