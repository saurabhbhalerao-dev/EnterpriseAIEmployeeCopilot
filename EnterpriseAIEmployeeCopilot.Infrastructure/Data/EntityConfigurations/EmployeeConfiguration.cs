using EnterpriseAIEmployeeCopilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAIEmployeeCopilot.Infrastructure.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Table
            builder.ToTable("Employees");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.EmployeeCode)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(x => x.FirstName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.LastName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Email)
                   .HasMaxLength(150)
                   .IsRequired();

            builder.Property(x => x.PasswordHash)
                   .HasMaxLength(500)
                   .IsRequired();

            // Unique Indexes
            builder.HasIndex(x => x.EmployeeCode)
                   .IsUnique();

            builder.HasIndex(x => x.Email)
                   .IsUnique();

            // Department Relationship
            builder.HasOne(x => x.Department)
                   .WithMany(x => x.Employees)
                   .HasForeignKey(x => x.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Designation Relationship
            builder.HasOne(x => x.Designation)
                   .WithMany(x => x.Employees)
                   .HasForeignKey(x => x.DesignationId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Role Relationship
            builder.HasOne(x => x.Role)
                   .WithMany(x => x.Employees)
                   .HasForeignKey(x => x.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Leave Balances
            builder.HasMany(x => x.LeaveBalances)
                   .WithOne(x => x.Employee)
                   .HasForeignKey(x => x.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Leave Requests
            builder.HasMany(x => x.LeaveRequests)
                   .WithOne(x => x.Employee)
                   .HasForeignKey(x => x.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Attendance
            builder.HasMany(x => x.Attendances)
                   .WithOne(x => x.Employee)
                   .HasForeignKey(x => x.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Refresh Tokens
            builder.HasMany(x => x.RefreshTokens)
                   .WithOne(x => x.Employee)
                   .HasForeignKey(x => x.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Uploaded Documents
            builder.HasMany(x => x.UploadedDocuments)
                   .WithOne(x => x.UploadedByEmployee)
                   .HasForeignKey(x => x.UploadedByEmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
