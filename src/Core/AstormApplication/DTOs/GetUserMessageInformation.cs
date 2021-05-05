using System;

namespace AstormApplication.DTOs
{
    public class GetUserMessageInformation
    {
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }
    }
}
