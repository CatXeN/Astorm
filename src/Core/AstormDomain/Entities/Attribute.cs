using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstormDomain.Entities
{
    public class Attribute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public Guid UserId { get; set; }
    }
}
