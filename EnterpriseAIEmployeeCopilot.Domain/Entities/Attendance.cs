using EnterpriseAIEmployeeCopilot.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAIEmployeeCopilot.Domain.Entities
{
    public class Attendance : BaseEntity
    {
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; } = null!;

        public DateOnly AttendanceDate { get; set; }

        public DateTime? FirstCheckIn { get; set; }

        public DateTime? LastCheckOut { get; set; }

        public AttendanceStatus Status { get; set; }

        public string? Remarks { get; set; }
    }
}
