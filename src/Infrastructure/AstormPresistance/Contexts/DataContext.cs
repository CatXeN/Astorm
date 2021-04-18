using AstormDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AstormPresistance.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<ChannelMessage> ChannelsMessages { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<UserMessage> UsersMessages { get; set; }
        public DbSet<AssignUsersToServer> AssignUsersToServers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<FriendOfUser> FriendsOfUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FriendOfUser>()
                .HasOne(p => p.Friend)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
