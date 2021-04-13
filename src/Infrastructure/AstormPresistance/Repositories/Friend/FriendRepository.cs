using AstormApplication.DTOs;
using AstormDomain.Entities;
using AstormPresistance.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            List<FriendOfUser> friends = new List<FriendOfUser>
            {
                new FriendOfUser()
                {
                  UserId = friendOfUserInformation.UserId,
                  FriendId = friendOfUserInformation.FriendId
                },
                new FriendOfUser() 
                {
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
    }
}
