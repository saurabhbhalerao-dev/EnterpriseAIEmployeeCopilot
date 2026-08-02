using EnterpriseAIEmployeeCopilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAIEmployeeCopilot.Infrastructure.Data.EntityConfiguations
{
    public class DesignationConfiguration : IEntityTypeConfiguration<Designation>
    {
        public void Configure(EntityTypeBuilder<Designation> builder)
        {
            // Table
            builder.ToTable("Designations");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            // Unique Index
            builder.HasIndex(x => x.Name)
                   .IsUnique();

            // Relationships
            builder.HasMany(x => x.Employees)
                   .WithOne(x => x.Designation)
                   .HasForeignKey(x => x.DesignationId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
