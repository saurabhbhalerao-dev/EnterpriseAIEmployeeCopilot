using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAIEmployeeCopilot.Domain.Entities
{
    public class ChatMessage : BaseEntity
    {
        public int ChatConversationId { get; set; }

        public ChatConversation ChatConversation { get; set; } = null!;

        public string Sender { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public int TokenUsage { get; set; }

        public DateTime SentOn { get; set; } = DateTime.UtcNow;
    }
}
