﻿using System;

namespace AstormApplication.DTOs
{
    public class PendingRequestInformation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid FriendId { get; set; }

        public UserInformation User { get; set; }
        public UserInformation Friend { get; set; }
    }
}