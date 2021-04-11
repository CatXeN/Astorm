using System.Threading.Tasks;
using Infrastructure.Identity.Models;

namespace Infrastructure.Identity.Repositories
{
    public interface IIdentityRepository
    {
        Task CreateUser(User user);
        Task<bool> UserAlreadyExist(string username);
        Task<User> FindUser(string username);
    }
}