using AstormDomain.Common;
using AstormDomain.Entities;
using AstormPresistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstormPresistance.Repositories.Messeges
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DataContext _context;

        public MessageRepository(DataContext context)
        {
            _context = context;
        }


        public async Task AddMessage(AstormDomain.Entities.UserMessage message)
        {
            await _context.UsersMessages.AddAsync(message);
            await _context.SaveChangesAsync();
        }
    }
}
