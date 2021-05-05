using AstormApplication.DTOs;
using AstormDomain.Entities;
using AstormPresistance.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstormPresistance.Repositories.Friend
{
    public class FriendRepository : IFriendRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public FriendRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddFriend(FriendOfUserInformation friendOfUserInformation)
        {
            var friends = new List<FriendOfUser>
            {
                new FriendOfUser()
                {
                    Id = Guid.NewGuid(), 
                    UserId = friendOfUserInformation.UserId,
                    FriendId = friendOfUserInformation.FriendId
                },
                new FriendOfUser() 
                {
                    Id = Guid.NewGuid(),
                    UserId = friendOfUserInformation.FriendId,
                    FriendId = friendOfUserInformation.UserId
                }
            };

            await _context.AddRangeAsync(friends);
            await _context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<FriendOfUserInformation>> GetFriendsOfUser(Guid userId)
        {
            var friends = await _context.FriendsOfUsers.Include(x => x.Friend).Where(x => x.UserId == userId).ToListAsync();
            return _mapper.Map<IEnumerable<FriendOfUserInformation>>(friends);
        }

        public async Task<bool> RemoveRequest(Guid userId, Guid friendId)
        {
            var request = await _context.PendingRequests
                .FirstOrDefaultAsync(x => x.UserId == userId && x.FriendId == friendId);
            
            if (request != null)
                _context.Remove(request);

            var deleted = await _context.SaveChangesAsync();
            
            return deleted > 0;
        }

        public async Task AddRequest(PendingRequestInformation pendingRequestInformation)
        {
            var pendingRequest = await _context.PendingRequests
                .FirstOrDefaultAsync(x => (x.UserId == pendingRequestInformation.UserId
                && x.FriendId == pendingRequestInformation.FriendId) || 
                (x.UserId == pendingRequestInformation.FriendId && x.FriendId == pendingRequestInformation.UserId));

            var friend = await _context.FriendsOfUsers
                .FirstOrDefaultAsync(x => x.UserId == pendingRequestInformation.UserId
                && x.FriendId == pendingRequestInformation.FriendId);

            if (pendingRequest != null || friend != null)
                throw new Exception("Such a request to friends already exists");

            var request = _mapper.Map<PendingRequest>(pendingRequestInformation);
            await _context.PendingRequests.AddAsync(request);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PendingRequestInformation>> GetPendingRequestList(Guid userId)
        {
            var result = await _context.PendingRequests
                .Include(x => x.Friend)
                .ThenInclude(x => x.Attributes)
                .ToListAsync();
            return _mapper.Map<IEnumerable<PendingRequestInformation>>(result);
        }
    }
}
