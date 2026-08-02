using EnterpriseAIEmployeeCopilot.Domain.Entities;
using EnterpriseAIEmployeeCopilot.Domain.Interfaces;
using EnterpriseAIEmployeeCopilot.Domain.Interfaces.Repositories;
using EnterpriseAIEmployeeCopilot.Infrastructure.Data;

namespace EnterpriseAIEmployeeCopilot.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Employees = new EmployeeRepository(_context);
            Departments = new Repository<Department>(_context);
            Designations = new Repository<Designation>(_context);
            Roles = new Repository<Role>(_context);
            Attendances = new Repository<Attendance>(_context);
            LeaveBalances = new Repository<LeaveBalance>(_context);
            LeaveRequests = new Repository<LeaveRequest>(_context);
            RefreshTokens = new Repository<RefreshToken>(_context);
            UploadedDocuments = new Repository<UploadedDocument>(_context);
            ChatConversations = new Repository<ChatConversation>(_context);
            ChatMessages = new Repository<ChatMessage>(_context);
            PromptTemplates = new Repository<PromptTemplate>(_context);
        }

        public IEmployeeRepository Employees { get; }

        public IRepository<Department> Departments { get; }

        public IRepository<Designation> Designations { get; }

        public IRepository<Role> Roles { get; }

        public IRepository<Attendance> Attendances { get; }

        public IRepository<LeaveBalance> LeaveBalances { get; }

        public IRepository<LeaveRequest> LeaveRequests { get; }

        public IRepository<RefreshToken> RefreshTokens { get; }

        public IRepository<UploadedDocument> UploadedDocuments { get; }

        public IRepository<ChatConversation> ChatConversations { get; }

        public IRepository<ChatMessage> ChatMessages { get; }

        public IRepository<PromptTemplate> PromptTemplates { get; }


        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}