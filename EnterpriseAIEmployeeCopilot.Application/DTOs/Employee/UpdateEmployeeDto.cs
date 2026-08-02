using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAIEmployeeCopilot.Application.DTOs.Employee
{
    public class UpdateEmployeeDto
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public int DepartmentId { get; set; }

        public int DesignationId { get; set; }

        public int RoleId { get; set; }

        public int? ManagerId { get; set; }

        public bool IsActive { get; set; }
    }
}
