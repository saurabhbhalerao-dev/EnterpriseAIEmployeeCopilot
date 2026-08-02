using EnterpriseAIEmployeeCopilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnterpriseAIEmployeeCopilot.Infrastructure.Data.EntityConfigurations
{
    public class UploadedDocumentConfiguration : IEntityTypeConfiguration<UploadedDocument>
    {
        public void Configure(EntityTypeBuilder<UploadedDocument> builder)
        {
            builder.ToTable("UploadedDocuments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.FileName)
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(x => x.BlobUrl)
                   .HasMaxLength(1000)
                   .IsRequired();

            builder.Property(x => x.ContentType)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.FileSize)
                   .IsRequired();

            builder.Property(x => x.IsIndexed)
                   .IsRequired();

            builder.HasOne(x => x.UploadedByEmployee)
                   .WithMany(x => x.UploadedDocuments)
                   .HasForeignKey(x => x.UploadedByEmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.DocumentType, x.IsIndexed });
        }
    }
}