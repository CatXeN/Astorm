using AstormApplication.Options;
using AstormPresistance.Repositories.User;
using FluentFTP;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AstormAPI.Services
{
    public class ImageService : IImageService
    {
        private readonly FTPConfig _ftpConfig;
        private readonly IFtpClient _ftpClient;
        private readonly IUserRepository _userRepository;

        public ImageService(IOptions<FTPConfig> ftpConfig, IFtpClient ftpClient, IUserRepository userRepository)
        {
            _ftpConfig = ftpConfig.Value;

            //FTP CLIENT INJECTION
            _ftpClient = ftpClient;
            _ftpClient.Credentials = new NetworkCredential(_ftpConfig.Username, _ftpConfig.Password);
            _ftpClient.Host = _ftpConfig.IpAdress;

            _userRepository = userRepository;
        }

        public async Task<string> ChangeImage(IFormFile file, Guid UserId)
        {
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);

            await _ftpClient.ConnectAsync();

            var files = await _ftpClient.GetListingAsync("");
            var userImage = files.FirstOrDefault(x => x.Name.Contains(UserId.ToString()));

            if (userImage != null)
                await _ftpClient.DeleteFileAsync(userImage.FullName);

            var fileExtenstion = file.FileName.Split('.');
            var fileName = UserId.ToString() + "." + fileExtenstion[1];

            var isSuccess = await _ftpClient.UploadAsync(stream, fileName);
            var link = string.Empty;

            if(isSuccess == FtpStatus.Success)
            {
                link = $"localhost/AstormImages/{fileName}";
                await _userRepository.ChangeImageUrl(UserId, link);
            }
            
            return link;
        }
    }
}
