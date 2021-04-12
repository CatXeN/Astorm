using System;
using System.Threading.Tasks;
using Infrastructure.Identity.Models;

namespace Infrastructure.Identity.Repositories
{
    public interface IIdentityRepository
    {
        Task<Guid> CreateUser(User user);
        Task<bool> UserAlreadyExist(string username);
        Task<User> FindUser(string username);
    }
}