using AstormDomain.Enums;
using AstormPresistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstormPresistance.Repositories.User
{
    public class UserRepository: IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task ChangeImageUrl(Guid userId, string url)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            user.ImageUrl = url;

            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeStatus(int status, Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            user.UserStatus = (UserStatus)status;

            _context.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
