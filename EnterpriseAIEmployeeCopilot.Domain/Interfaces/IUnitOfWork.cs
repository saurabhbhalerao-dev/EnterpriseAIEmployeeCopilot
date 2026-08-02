using EnterpriseAIEmployeeCopilot.Domain.Entities;
using EnterpriseAIEmployeeCopilot.Domain.Interfaces.Repositories;

namespace EnterpriseAIEmployeeCopilot.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }


        IRepository <Department> Departments { get; }

        IRepository<Designation> Designations { get; }

        IRepository<Role> Roles { get; }

        IRepository<Attendance> Attendances { get; }

        IRepository<LeaveBalance> LeaveBalances { get; }

        IRepository<LeaveRequest> LeaveRequests { get; }

        IRepository<RefreshToken> RefreshTokens { get; }

        IRepository<UploadedDocument> UploadedDocuments { get; }

        IRepository<ChatConversation> ChatConversations { get; }

        IRepository<ChatMessage> ChatMessages { get; }

        IRepository<PromptTemplate> PromptTemplates { get; }

        Task<int> SaveChangesAsync();
    }
}