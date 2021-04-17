

using AstormDomain.Entities;
using System.Threading.Tasks;

namespace AstormPresistance.Repositories.Messeges
{
    public interface IMessageRepository
    {
        Task AddMessage(UserMessage message);
    }
}
