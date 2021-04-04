using System;

namespace AstormDomain.Models.Information
{
    public class UserMessageInformation : MessageInformation
    {
        public Guid RecipientId { get; set; }
    }
}