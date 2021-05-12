using AstormApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstormPresistance.Repositories.Friend
{
    public interface IFriendRepository
    {
        Task AddFriend(FriendOfUserInformation friendOfUserInformation);
        Task<IEnumerable<FriendOfUserInformation>> GetFriendsOfUser(Guid userId);
        Task<bool> RemoveRequest(Guid userId, Guid friendId);
        Task AddRequest(PendingRequestInformation pendingRequestInformation);
        Task<IEnumerable<PendingRequestInformation>> GetPendingRequestList(Guid userId);
        Task<Guid> UserExist(string addRequestFriendInfromation);
    }
}
