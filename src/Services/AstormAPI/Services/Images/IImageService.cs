using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstormAPI.Services
{
    public interface IImageService
    {
        Task<string> ChangeImage(IFormFile file, Guid UserId);
    }
}
