using System;

namespace AstormDomain.Models.Information
{
    public class MessageInformation
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime SendMessageDate { get; set; }
        public Guid UserId { get; set; }
    }
}
