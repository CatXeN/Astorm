using System;
using System.ComponentModel.DataAnnotations.Schema;
using AstormDomain.Common;

namespace AstormDomain.Entities
{
    public class UserMessage : Common.UserMessage
    {
        public Guid RecipientId { get; set; }
        
        [ForeignKey("RecipientId")]
        public virtual User Recipient { get; set; }
    }
}
