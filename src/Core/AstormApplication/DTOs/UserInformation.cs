using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using AstormDomain.Entities;
using AstormDomain.Enums;

namespace AstormApplication.DTOs
{
    public class UserInformation
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public UserStatus UserStatus { get; set; }

        public ICollection<AstormDomain.Entities.Attribute> Attributes { get; set; }
    }
}
