using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstormApplication.DTOs
{
    public class AddRequestFriendInfromation
    {
        public Guid UserId { get; set; }
        public string UserToAdd { get; set; }
    }
}
