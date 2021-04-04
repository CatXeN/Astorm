using System;
using AstormDomain.Entities;

namespace AstormApplication.DTOs
{
    public class ChannelMessageInformation : MessageInformation
    {
        public Guid ChannelId { get; set; }
        public Channel Channel{ get; set; }
    }
}