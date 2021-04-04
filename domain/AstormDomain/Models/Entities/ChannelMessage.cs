using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstormDomain.Models.Entities
{
    public class ChannelMessage : Message
    {
        public Guid ChannelId { get; set; }

        [ForeignKey("ChannelId")]
        public virtual Channel Channel{ get; set; }
    }
}
