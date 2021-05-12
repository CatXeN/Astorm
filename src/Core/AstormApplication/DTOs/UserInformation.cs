using System;
using System.Collections.Generic;
using AstormDomain.Enums;

namespace AstormApplication.DTOs
{
    public class UserInformation
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public UserStatus UserStatus { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<AstormDomain.Entities.Attribute> Attributes { get; set; }
    }
}
