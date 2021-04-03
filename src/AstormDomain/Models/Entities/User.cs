using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstormDomain.Models.Entities
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
        
        public string Phone { get; set; }
        
        public string Photo { get; set; }
        
        public string Description { get; set; }
    }
}