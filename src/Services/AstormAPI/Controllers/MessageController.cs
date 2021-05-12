using AstormApplication.DTOs;
using AstormPresistance.Repositories.Messeges;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AstormAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessageController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> GetMessages(GetUserMessageInformation getUserMessageInformation)
        {
            var messages = await _messageRepository.GetUserMessage(getUserMessageInformation);
            return Ok(messages);
        }
    }
}
