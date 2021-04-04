using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace AstormDomain.Entities
{
    public class Channel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ServerId { get; set; }
        
        [ForeignKey("ServerId")]
        public virtual Server Server { get; set; }
        public ICollection<ChannelMessage> ChannelMessages { get; } = new List<ChannelMessage>();
    }
}
