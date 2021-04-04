using System;
using AstormDomain.Entities;

namespace AstormApplication.DTOs
{
    public class UserMessageInformation : MessageInformation
    {
        public Guid RecipientId { get; set; }
        public User Recipient { get; set; }
    }
}