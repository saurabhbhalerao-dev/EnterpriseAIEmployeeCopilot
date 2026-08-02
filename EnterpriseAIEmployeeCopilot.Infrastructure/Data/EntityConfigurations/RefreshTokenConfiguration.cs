using EnterpriseAIEmployeeCopilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAIEmployeeCopilot.Infrastructure.Data.EntityConfigurations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("RefreshTokens");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Token)
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(x => x.ExpiryDate)
                   .IsRequired();

            builder.Property(x => x.IsRevoked)
                   .IsRequired();

            builder.HasOne(x => x.Employee)
                   .WithMany(x => x.RefreshTokens)
                   .HasForeignKey(x => x.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.Token)
                   .IsUnique();
        }
    }
}
