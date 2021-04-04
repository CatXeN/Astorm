using System;
using System.Collections;
using System.Collections.Generic;
using AstormDomain.Models.Entities;

namespace AstormDomain.Models.Information
{
    public class UserInformation
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        
        public IEnumerable<UserMessage> OwnerMessages { get; }
        public IEnumerable<UserMessage> RecipientMessages { get; }
        public IEnumerable<ChannelMessage> UserMessages { get; }
    }
}
