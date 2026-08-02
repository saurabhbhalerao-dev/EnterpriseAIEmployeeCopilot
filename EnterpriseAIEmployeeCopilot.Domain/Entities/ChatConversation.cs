using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAIEmployeeCopilot.Domain.Entities
{
    public class ChatConversation : BaseEntity
    {
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; } = null!;

        public string Title { get; set; } = string.Empty;

        public ICollection<ChatMessage> Messages { get; set; }
            = new List<ChatMessage>();
    }
}
