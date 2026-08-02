using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAIEmployeeCopilot.Application.DTOs.Employee
{
    public class EmployeeDetailsDto
    {
        public int Id { get; set; }

        public string EmployeeCode { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public DateTime DateOfJoining { get; set; }

        public bool IsActive { get; set; }

        public string Department { get; set; } = string.Empty;

        public string Designation { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public string? ManagerName { get; set; }
    }
}
