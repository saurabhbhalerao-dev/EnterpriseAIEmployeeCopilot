using EnterpriseAIEmployeeCopilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAIEmployeeCopilot.Infrastructure.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<LeaveBalance> LeaveBalances => Set<LeaveBalance>();

        public DbSet<LeaveRequest> LeaveRequests => Set<LeaveRequest>();

        public DbSet<Attendance> Attendances => Set<Attendance>();
        public DbSet<Department> Departments => Set<Department>();

        public DbSet<Designation> Designations => Set<Designation>();

        public DbSet<Role> Roles => Set<Role>();

        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

        public DbSet<UploadedDocument> UploadedDocuments => Set<UploadedDocument>();

        public DbSet<ChatConversation> ChatConversations => Set<ChatConversation>();

        public DbSet<ChatMessage> ChatMessages => Set<ChatMessage>();

        public DbSet<PromptTemplate> PromptTemplates => Set<PromptTemplate>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Employee>()
            //    .HasIndex(e => e.Email)
            //    .IsUnique();

            //modelBuilder.Entity<Employee>()
            //    .HasIndex(e => e.EmployeeCode)
            //    .IsUnique();
            //modelBuilder.Entity<Department>()
            //    .HasIndex(x => x.Name)
            //    .IsUnique();

            //modelBuilder.Entity<Designation>()
            //    .HasIndex(x => x.Name)
            //    .IsUnique();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
