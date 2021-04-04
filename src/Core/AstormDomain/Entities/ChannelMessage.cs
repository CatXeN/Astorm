using System;
using System.ComponentModel.DataAnnotations.Schema;
using AstormDomain.Common;

namespace AstormDomain.Entities
{
    public class ChannelMessage : Message
    {
        public Guid ChannelId { get; set; }

        [ForeignKey("ChannelId")]
        public virtual Channel Channel{ get; set; }
    }
}
