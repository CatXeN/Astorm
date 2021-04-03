using System;

namespace AstormDomain.Models.Entities
{
    public class UserMessage : Message
    {
        public Guid RecipientId { get; set; }

        public virtual User Recipient { get; set; }
    }
}
