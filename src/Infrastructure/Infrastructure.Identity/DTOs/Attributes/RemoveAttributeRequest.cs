using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.DTOs.Attributes
{
    public class RemoveAttributeRequest
    {
        public string Key { get; set; }
        public Guid UserId { get; set; }
    }
}
