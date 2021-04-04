using System;
using System.Collections.Generic;
using AstormDomain.Entities;

namespace AstormApplication.DTOs
{
    public class ChannelInformation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ServerId { get; set; }
        public Server Server { get; set; }
        public IEnumerable<ChannelMessage> ChannelMessages { get; }
        
    }
}
