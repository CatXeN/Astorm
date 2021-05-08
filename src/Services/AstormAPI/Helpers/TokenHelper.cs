using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace AstormAPI.Helpers
{
    public static class TokenHelper
    {
        public static Guid GetUserId(string jwt)
        {
            if(jwt.Contains("Bearer"))
            {
                var splitedToken = jwt.Split(' ');
                jwt = splitedToken[1];
            }

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);

            var userId = token.Claims.FirstOrDefault(claim => claim.Type == "nameid").Value;
            return Guid.Parse(userId);
        }
    }
}
