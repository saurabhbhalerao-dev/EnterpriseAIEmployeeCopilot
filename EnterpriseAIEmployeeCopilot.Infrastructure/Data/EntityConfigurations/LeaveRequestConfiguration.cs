using EnterpriseAIEmployeeCopilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAIEmployeeCopilot.Infrastructure.EntityConfigurations
{
    public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
    {
        public void Configure(EntityTypeBuilder<LeaveRequest> builder)
        {
            // Table
            builder.ToTable("LeaveRequests");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Reason)
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(x => x.Status)
                   .IsRequired();

            builder.Property(x => x.ApproverRemarks)
                   .HasMaxLength(500);

            builder.Property(x => x.LeaveType)
                   .IsRequired();

            builder.Property(x => x.FromDate)
                   .IsRequired();

            builder.Property(x => x.ToDate)
                   .IsRequired();

            // Employee requesting leave
            builder.HasOne(x => x.Employee)
                   .WithMany(x => x.LeaveRequests)
                   .HasForeignKey(x => x.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Manager approving leave
            builder.HasOne(x => x.ApprovedByEmployee)
                   .WithMany()
                   .HasForeignKey(x => x.ApprovedByEmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Helpful index for filtering
            builder.HasIndex(x => new
            {
                x.EmployeeId,
                x.Status
            });
        }
    }
}
