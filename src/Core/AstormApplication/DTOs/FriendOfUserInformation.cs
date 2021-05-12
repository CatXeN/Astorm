using AstormDomain.Entities;
using System;

namespace AstormApplication.DTOs
{
    public class FriendOfUserInformation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }
        public User User { get; set; }
        public User Friend { get; set; }
    }
}
