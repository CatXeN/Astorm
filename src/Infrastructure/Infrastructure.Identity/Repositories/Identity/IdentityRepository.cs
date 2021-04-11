using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Identity.Contexts;
using Infrastructure.Identity.DTOs;
using Infrastructure.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Identity.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly AuthContext _context;

        public IdentityRepository(AuthContext context)
        {
            _context = context;
        }
        
        public async Task CreateUser(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UserAlreadyExist(string username) => await _context.Users.AnyAsync(x => x.Username == username);
        public async Task<User> FindUser(string username) => await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
        
    }
}