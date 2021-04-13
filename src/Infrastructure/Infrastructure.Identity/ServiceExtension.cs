using System.Text;
using Infrastructure.Identity.Options;
using Infrastructure.Identity.Repositories;
using Infrastructure.Identity.Repositories.Attributes;
using Infrastructure.Identity.Services.Attributes;
using Infrastructure.Identity.Services.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Identity
{
    public static class ServiceExtension
    {
        public static void AddAuthenticationLibrary(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<IIdentityRepository, IdentityRepository>();
            services.AddTransient<IAttributeService, AttributeService>();
            services.AddTransient<IAttributeRepository, AttributeRepository>();

            services.Configure<TokenConfig>(options => configuration.GetSection("Token").Bind(options));

            var tokenConfigurationSection = configuration.GetSection("Token");
            var tokenConfig = tokenConfigurationSection.Get<TokenConfig>();
            var key = Encoding.ASCII.GetBytes(tokenConfig.SecurityKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }
    }
}