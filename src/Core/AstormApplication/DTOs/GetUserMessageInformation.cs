using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstormApplication.DTOs
{
    public class GetUserMessageInformation
    {
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }
    }
}
