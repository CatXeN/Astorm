using System;
using AstormDomain.Models.Entities;

namespace AstormDomain.Models.Information
{
    public class MessageInformation
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime SendMessageDate { get; set; }
        public Guid OwnerId { get; set; }
        public User Owner { get; set; }
    }
}
