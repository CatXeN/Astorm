using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Identity.DTOs;
using Infrastructure.Identity.Helpers;
using Infrastructure.Identity.Repositories;
using Microsoft.IdentityModel.Tokens;
using Infrastructure.Identity.Options;
using Microsoft.Extensions.Options;
using Infrastructure.Identity.Repositories.Attributes;
using System.Linq;
using System.Collections.Generic;
using AstormDomain.Entities;

namespace Infrastructure.Identity.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IIdentityRepository _repository;
        private readonly IAttributeRepository _attributeRepository;
        private readonly TokenConfig _config;

        public IdentityService(IIdentityRepository repository, IAttributeRepository attributeRepository, IOptions<TokenConfig> config)
        {
            _repository = repository;
            _config = config.Value;
            _attributeRepository = attributeRepository;
        }
        
        public async Task<bool> CreateUser(SignUpRequest signUpRequest)
        {
             if (await _repository.UserAlreadyExist(signUpRequest.Username))
             {
                 throw new InvalidOperationException("This username is already taken.");
             }

             EncryptHelper.CreatePasswordHashAndSalt(signUpRequest.Password, out var hash, out var salt);

             var user = new User()
             {
                 Username = signUpRequest.Username,
                 PasswordHash = hash,
                 PasswordSalt = salt
             };

             var userId = await _repository.CreateUser(user);

            if (signUpRequest.Attributes.Count > 0)
            {
                List<AstormDomain.Entities.Attribute> attributes = new List<AstormDomain.Entities.Attribute>();

                foreach (var item in signUpRequest.Attributes)
                {
                    attributes = signUpRequest.Attributes.Select(x => new AstormDomain.Entities.Attribute
                    {
                        UserId = userId,
                        Key = x.Key,
                        Value = x.Value
                    }).ToList();
                }

                await _attributeRepository.AddAttributes(attributes);
            }

             return true;
        }

        public async Task<string> Login(SignInRequest signInRequest)
        {
            var user = await _repository.FindUser(signInRequest.Username);
            
            if (user == null)
                throw new Exception("Username or password is wrong");

            if (!EncryptHelper.VerifyPasswordHash(signInRequest.Password, user.PasswordHash, user.PasswordSalt))
                throw new Exception("Username or password is wrong");

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                // new Claim(ClaimTypes.Role, EnumHelper.GetDescription(user.Role))
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(24),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        
        public Task<bool> Authorize(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
