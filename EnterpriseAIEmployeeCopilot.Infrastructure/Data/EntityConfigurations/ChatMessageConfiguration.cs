using EnterpriseAIEmployeeCopilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnterpriseAIEmployeeCopilot.Infrastructure.Data.EntityConfigurations
{
    public class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
    {
        public void Configure(EntityTypeBuilder<ChatMessage> builder)
        {
            builder.ToTable("ChatMessages");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Sender)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.Message)
                   .HasMaxLength(4000)
                   .IsRequired();

            builder.Property(x => x.TokenUsage)
                   .IsRequired();

            builder.HasOne(x => x.ChatConversation)
                   .WithMany(x => x.Messages)
                   .HasForeignKey(x => x.ChatConversationId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.ChatConversationId);
        }
    }
}