using AstormApplication.DTOs;
using AstormPresistance.Repositories.Friend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstormAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendRepository _repository;
        public FriendController(IFriendRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> AddFriend(FriendOfUserInformation friendOfUserInformation)
        {
            await _repository.AddFriend(friendOfUserInformation);
            return Ok(); 
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetFriendsOfUser(Guid userId)
        {
            var friends =  await _repository.GetFriendsOfUser(userId);
            return Ok(friends);
        }

    }
}
