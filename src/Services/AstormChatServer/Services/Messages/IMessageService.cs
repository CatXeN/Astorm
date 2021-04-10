using AstormDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstormChatServer.Services.Messages
{
    public interface IMessageService
    {
        Task AddMessage(Message message);
    }
}
