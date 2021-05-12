using AstormApplication.DTOs;
using AstormPresistance.Repositories.Friend;
using Microsoft.AspNetCore.Mvc;
using System;
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
        
        [HttpPost("addRequest")]
        public async Task<IActionResult> AddRequest(AddRequestFriendInfromation addRequestFriendInfromation)
        {
            var friend = await _repository.UserExist(addRequestFriendInfromation.UserToAdd);

            if (friend == Guid.Empty)
                return BadRequest("User not exist");

            var pendingRequestInformation = new PendingRequestInformation()
            {
                FriendId = friend,
                UserId = addRequestFriendInfromation.UserId
            };

            try
            {
                await _repository.AddRequest(pendingRequestInformation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok(); 
        }

        [HttpDelete("declineRequest/{userId}&{friendId}")]
        public async Task<IActionResult> RemoveRequest(Guid userId, Guid friendId)
        {
            await _repository.RemoveRequest(userId, friendId);
            return Ok();
        }
        
        [HttpPost("acceptRequest")]
        public async Task<IActionResult> AcceptRequest(FriendOfUserInformation friendOfUserInformation)
        {
            var successful = await _repository.RemoveRequest(friendOfUserInformation.UserId, friendOfUserInformation.FriendId);

            if (!successful) 
                return BadRequest();

            await _repository.AddFriend(friendOfUserInformation);
            return Ok();
        }

        [HttpGet("getRequest/{userId}")]
        public async Task<IActionResult> GetPendingRequest(Guid userId)
        {
            var result = await _repository.GetPendingRequestList(userId);
            return Ok(result);
        }
    }
}
