using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using AstormDomain.Entities;

namespace AstormApplication.DTOs
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
    }
}
