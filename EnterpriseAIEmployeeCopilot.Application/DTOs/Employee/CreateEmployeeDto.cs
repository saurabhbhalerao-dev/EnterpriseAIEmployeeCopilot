using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAIEmployeeCopilot.Application.DTOs.Employee
{
    public class CreateEmployeeDto
    {
        public string EmployeeCode { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public int DepartmentId { get; set; }

        public int DesignationId { get; set; }

        public int RoleId { get; set; }

        public int? ManagerId { get; set; }

        public DateTime DateOfJoining { get; set; }
    }
}
