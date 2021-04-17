using AstormPresistance.Contexts;
using AstormPresistance.Repositories.Friend;
using AstormPresistance.Repositories.Messeges;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace AstormPresistance
{
    public static class ServiceRegisterExtension
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),b => b.MigrationsAssembly("AstormAPI")));

            services.AddTransient<IFriendRepository, FriendRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
        }
    }
}