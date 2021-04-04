using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstormDomain.Entities
{
    public class User
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [StringLengthAttribute(11, MinimumLength = 0)]
        public string Phone { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }

        public ICollection<UserMessage> OwnerMessages { get; } = new List<UserMessage>();
        public ICollection<UserMessage> RecipientMessages { get; } = new List<UserMessage>();
        public ICollection<ChannelMessage> UserMessages { get; } = new List<ChannelMessage>();
    }
}
