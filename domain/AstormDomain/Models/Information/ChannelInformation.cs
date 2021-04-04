using System;
using System.Collections;
using System.Collections.Generic;
using AstormDomain.Models.Entities;

namespace AstormDomain.Models.Information
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
