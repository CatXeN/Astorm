using AstormDomain.Enums;
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
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public UserStatus UserStatus { get; set; }

        public ICollection<UserMessage> OwnerMessages { get; } = new List<UserMessage>();
        public ICollection<UserMessage> RecipientMessages { get; } = new List<UserMessage>();
        public ICollection<ChannelMessage> UserMessages { get; } = new List<ChannelMessage>();
    }
}