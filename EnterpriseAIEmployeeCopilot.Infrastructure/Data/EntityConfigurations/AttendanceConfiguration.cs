using EnterpriseAIEmployeeCopilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAIEmployeeCopilot.Infrastructure.Data.EntityConfiguations;

public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.ToTable("Attendances");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.AttendanceDate)
               .IsRequired();

        builder.Property(x => x.Status)
               .IsRequired();

        builder.Property(x => x.Remarks)
               .HasMaxLength(500);

        builder.HasOne(x => x.Employee)
               .WithMany(x => x.Attendances)
               .HasForeignKey(x => x.EmployeeId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new
        {
            x.EmployeeId,
            x.AttendanceDate
        }).IsUnique();
    }
}
