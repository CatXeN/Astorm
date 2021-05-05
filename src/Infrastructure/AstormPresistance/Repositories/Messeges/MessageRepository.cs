using AstormApplication.DTOs;
using AstormPresistance.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstormPresistance.Repositories.Messeges
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MessageRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserMessageInformation>> GetUserMessage(GetUserMessageInformation getUserMessageInformation)
        {
            var messages = await _context.UsersMessages
                .Include(x => x.Owner)
                .OrderBy(y => y.SendMessageDate)
                .Where(x => (x.OwnerId == getUserMessageInformation.FriendId || x.OwnerId == getUserMessageInformation.UserId) 
                && (x.RecipientId == getUserMessageInformation.FriendId|| x.RecipientId == getUserMessageInformation.UserId))
                .ToListAsync();

            return _mapper.Map<IEnumerable<UserMessageInformation>>(messages);
        }
    }
}
