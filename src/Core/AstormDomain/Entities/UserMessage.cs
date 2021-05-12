using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstormDomain.Entities
{
    public class UserMessage : Common.UserMessage
    {
        public Guid RecipientId { get; set; }
        
        [ForeignKey("RecipientId")]
        public virtual User Recipient { get; set; }
    }
}
