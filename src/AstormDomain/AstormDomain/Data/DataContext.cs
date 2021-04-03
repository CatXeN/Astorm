using AstormDomain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AstormDomain.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<ChannelMessage> ChannelsMessages { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserMessage> UsersMessages { get; set; }
    }
}
