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
        public DbSet<PendingRequest> PendingRequests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<FriendOfUser> FriendsOfUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FriendOfUser>()
                .HasOne(p => p.Friend)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<PendingRequest>()
                .HasOne(p => p.User)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<UserMessage>()
                .HasOne(p => p.Recipient)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<UserMessage>()
                .HasOne(p => p.Owner)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<ChannelMessage>()
                .HasOne(p => p.Channel)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<ChannelMessage>()
                .HasOne(p => p.Owner)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
