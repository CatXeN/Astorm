using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.DTOs
{
    public class AddAttributeRequest
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public Guid UserId { get; set; }
    }
}
