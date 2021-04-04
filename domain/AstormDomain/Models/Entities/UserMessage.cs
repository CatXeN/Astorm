using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstormDomain.Models.Entities
{
    public class UserMessage : Message
    {
        public Guid RecipientId { get; set; }
        
        [ForeignKey("RecipientId")]
        public virtual User Recipient { get; set; }
    }
}
