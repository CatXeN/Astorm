using System;
using AstormDomain.Models.Entities;

namespace AstormDomain.Models.Information
{
    public class UserMessageInformation : MessageInformation
    {
        public Guid RecipientId { get; set; }
        public User Recipient { get; set; }
    }
}