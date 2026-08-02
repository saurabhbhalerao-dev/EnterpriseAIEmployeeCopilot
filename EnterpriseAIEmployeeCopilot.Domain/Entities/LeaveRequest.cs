using EnterpriseAIEmployeeCopilot.Domain.Enums;

namespace EnterpriseAIEmployeeCopilot.Domain.Entities
{
    public class LeaveRequest : BaseEntity
    {
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; } = null!;

        public LeaveType LeaveType { get; set; }

        public DateOnly FromDate { get; set; }

        public DateOnly ToDate { get; set; }

        public string Reason { get; set; } = string.Empty;

        public LeaveStatus Status { get; set; } = LeaveStatus.Pending;

        public int? ApprovedByEmployeeId { get; set; }

        public Employee? ApprovedByEmployee { get; set; }

        public DateTime? ApprovedDate { get; set; }

        public string? ApproverRemarks { get; set; }
    }
}