using System;
using System.Threading.Tasks;
using AstormDomain.Entities;
using AstormPresistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly DataContext _context;

        public IdentityRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<Guid> CreateUser(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<bool> UserAlreadyExist(string username) => await _context.Users.AnyAsync(x => x.Username == username);
        public async Task<User> FindUser(string username) => await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
        
    }
}