using EnterpriseAIEmployeeCopilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnterpriseAIEmployeeCopilot.Infrastructure.Data.EntityConfigurations
{
    public class PromptTemplateConfiguration : IEntityTypeConfiguration<PromptTemplate>
    {
        public void Configure(EntityTypeBuilder<PromptTemplate> builder)
        {
            builder.ToTable("PromptTemplates");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .HasMaxLength(500);

            builder.Property(x => x.SystemPrompt)
                   .IsRequired();

            builder.HasIndex(x => x.Name)
                   .IsUnique();
        }
    }
}