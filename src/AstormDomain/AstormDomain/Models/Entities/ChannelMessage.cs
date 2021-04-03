using System;

namespace AstormDomain.Models.Entities
{
    public class ChannelMessage : Message
    {
        public Guid ChannelId { get; set; }
        
        public virtual Channel Channel{ get; set; }
    }
}
