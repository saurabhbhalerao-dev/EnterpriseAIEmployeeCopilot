using EnterpriseAIEmployeeCopilot.Domain.Enums;

namespace EnterpriseAIEmployeeCopilot.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string EmployeeCode { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public int DepartmentId { get; set; }

        public int DesignationId { get; set; }

        public Department Department { get; set; } = null!;

        public Designation Designation { get; set; } = null!;

        //public string Department { get; set; } = string.Empty;

        //public string Designation { get; set; } = string.Empty;

        public DateTime DateOfJoining { get; set; }

        public bool IsActive { get; set; } = true;

        public int RoleId { get; set; }

        public Role Role { get; set; } = null!;
        public string? PhoneNumber { get; set; }

        //public DateTime JoiningDate { get; set; }
        
        public int? ManagerId { get; set; }

        public Employee? Manager { get; set; }

        public ICollection<Employee> TeamMembers { get; set; } = new List<Employee>();

        public EmployeeStatus Status { get; set; } = EmployeeStatus.Active;
        public ICollection<LeaveBalance> LeaveBalances { get; set; }
            = new List<LeaveBalance>();

        public ICollection<LeaveRequest> LeaveRequests { get; set; }
            = new List<LeaveRequest>();
        
        public ICollection<Attendance> Attendances { get; set; }
            = new List<Attendance>();

        public ICollection<RefreshToken> RefreshTokens { get; set; }
            = new List<RefreshToken>();
        public ICollection<UploadedDocument> UploadedDocuments { get; set; }
    = new List<UploadedDocument>();

        public ICollection<ChatConversation> ChatConversations { get; set; }
    = new List<ChatConversation>();

    }
}
