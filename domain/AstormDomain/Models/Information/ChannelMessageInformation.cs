using System;
using AstormDomain.Models.Entities;

namespace AstormDomain.Models.Information
{
    public class ChannelMessageInformation : MessageInformation
    {
        public Guid ChannelId { get; set; }
        public Channel Channel{ get; set; }
    }
}