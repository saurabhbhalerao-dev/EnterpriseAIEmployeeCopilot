using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseAIEmployeeCopilot.Domain.Entities
{
    public class PromptTemplate : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string SystemPrompt { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
