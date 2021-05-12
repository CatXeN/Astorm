using AstormAPI.Helpers;
using AstormAPI.Services;
using Microsoft.AspNetCore.Authorization;
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
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [Authorize()]
        [HttpPost]
        public async Task<IActionResult> ChangeImage(IFormFile FormFile)
        {
            var userId = TokenHelper.GetUserId(Request.Headers["Authorization"]);
            var path = await _imageService.ChangeImage(FormFile, userId);

            return Ok(path);
        }
    }
}
