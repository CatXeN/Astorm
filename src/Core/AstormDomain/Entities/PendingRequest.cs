using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstormDomain.Entities
{
    public class PendingRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User{ get; set; }
        
        [ForeignKey("FriendId")]
        public virtual User Friend{ get; set; }
    }
}