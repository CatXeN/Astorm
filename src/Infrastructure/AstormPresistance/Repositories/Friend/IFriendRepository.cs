using AstormApplication.DTOs;
using AstormDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstormPresistance.Repositories.Friend
{
    public interface IFriendRepository
    {
        Task AddFriend(FriendOfUserInformation friendOfUserInformation);
        Task<IEnumerable<FriendOfUserInformation>> GetFriendsOfUser(Guid userId);
    }
}
