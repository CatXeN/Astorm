using AstormApplication.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AstormPresistance.Repositories.Messeges
{
    public interface IMessageRepository
    {
        Task<IEnumerable<UserMessageInformation>> GetUserMessage(GetUserMessageInformation getUserMessageInformation);
    }
}
