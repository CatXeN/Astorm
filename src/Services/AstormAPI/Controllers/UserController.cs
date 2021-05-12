using AstormPresistance.Repositories.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AstormAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("changeStatus/{status}&{userId}")]
        public async Task<IActionResult> ChangeStatus(int status, Guid userId)
        {
            await _repository.ChangeStatus(status, userId);
            return Ok();
        }
    }
}
