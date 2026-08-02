using EnterpriseAIEmployeeCopilot.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAIEmployeeCopilot.Domain.Entities
{
    public class UploadedDocument : BaseEntity
    {
        public int UploadedByEmployeeId { get; set; }

        public Employee UploadedByEmployee { get; set; } = null!;

        public string Title { get; set; } = string.Empty;

        public DocumentType DocumentType { get; set; }

        public string FileName { get; set; } = string.Empty;

        public string BlobUrl { get; set; } = string.Empty;

        public string ContentType { get; set; } = string.Empty;

        public long FileSize { get; set; }

        public bool IsIndexed { get; set; }

        public DateTime UploadedOn { get; set; } = DateTime.UtcNow;
    }
}
