using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstormDomain.Models.Entities
{
    public class User
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("Recipient")]
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
    }
}
