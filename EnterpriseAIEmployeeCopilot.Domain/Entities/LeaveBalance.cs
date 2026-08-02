using EnterpriseAIEmployeeCopilot.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAIEmployeeCopilot.Domain.Entities
{
    public class LeaveBalance : BaseEntity
    {
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; } = null!;

        public LeaveType LeaveType { get; set; }

        // NEW
        public int Year { get; set; }

        public decimal TotalLeaves { get; set; }

        public decimal UsedLeaves { get; set; }

        public decimal RemainingLeaves { get; set; }
    }
}
