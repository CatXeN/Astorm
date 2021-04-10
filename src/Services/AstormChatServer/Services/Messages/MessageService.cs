using AstormApplication.Interfaces;
using AstormDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstormChatServer.Services.Messages
{
    public class MessageService : IMessageService
    {
        private readonly IGenericRepositoryAsync<Message> _messageRepository;

        public MessageService(IGenericRepositoryAsync<Message> messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task AddMessage(Message message)
        {
            await _messageRepository.AddAsync(message);
        }
    }
}
