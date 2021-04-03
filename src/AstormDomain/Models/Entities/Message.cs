using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstormDomain.Models.Entities
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        public string Content { get; set; }

        public DateTime SendMessageDate { get; set; }
        
        public virtual User User{ get; set; }
        
        public Guid UserId { get; set; }
    }
}