using Infrastructure.Identity.DTOs.Attributes;
using System.Collections.Generic;

namespace Infrastructure.Identity.DTOs
{
    public class SignUpRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<AttributeDto> Attributes { get; set; }
    }
}