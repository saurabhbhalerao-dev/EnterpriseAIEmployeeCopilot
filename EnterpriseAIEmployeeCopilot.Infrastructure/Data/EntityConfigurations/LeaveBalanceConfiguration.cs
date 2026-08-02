using EnterpriseAIEmployeeCopilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAIEmployeeCopilot.Infrastructure.EntityConfigurations
{
    public class LeaveBalanceConfiguration : IEntityTypeConfiguration<LeaveBalance>
    {
        public void Configure(EntityTypeBuilder<LeaveBalance> builder)
        {
            // Table
            builder.ToTable("LeaveBalances");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Year)
                   .IsRequired();

            builder.Property(x => x.TotalLeaves)
                   .HasPrecision(5, 2);

            builder.Property(x => x.UsedLeaves)
                   .HasPrecision(5, 2);

            builder.Property(x => x.RemainingLeaves)
                   .HasPrecision(5, 2);

            // Relationship
            builder.HasOne(x => x.Employee)
                   .WithMany(x => x.LeaveBalances)
                   .HasForeignKey(x => x.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);

            // One Leave Type per Employee per Year
            builder.HasIndex(x => new
            {
                x.EmployeeId,
                x.LeaveType,
                x.Year
            }).IsUnique();
        }
    }
}
