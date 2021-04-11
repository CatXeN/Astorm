using Infrastructure.Identity.DTOs;
using Infrastructure.Identity.Services.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AstormAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> CreateAccount(SignUpRequest registerInformation)
        {
            await _identityService.CreateUser(registerInformation);
            return Ok();
        }

        [HttpPost("Authorization")]
        public async Task<IActionResult> Authorization(SignInRequest loginInformation)
        {
            var token = await _identityService.Login(loginInformation);
            return Ok(token);
        }
    }
}
