using Infrastructure.Identity.Models;
using System;
using System.Threading.Tasks;
using Infrastructure.Identity.DTOs;

namespace Infrastructure.Identity.Services.Identity
{
    public interface IIdentityService
    {
        Task<bool> CreateUser(SignUpRequest signUpRequest);
        Task<string> Login(SignInRequest signInRequest);
        Task<bool> Authorize(Guid userId);
    }
}
