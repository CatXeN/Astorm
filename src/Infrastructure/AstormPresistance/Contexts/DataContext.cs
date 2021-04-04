using AstormDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AstormPresistance.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<ChannelMessage> ChannelsMessages { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserMessage> UsersMessages { get; set; }
        public DbSet<AssignUsersToServer> AssignUsersToServers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMessage>()
                .HasOne(p => p.Recipient)
                .WithMany(t => t.RecipientMessages)
                .HasForeignKey(f => f.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<UserMessage>()
                .HasOne(p => p.Owner)
                .WithMany(t => t.OwnerMessages)
                .HasForeignKey(f => f.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<ChannelMessage>()
                .HasOne(p => p.Channel)
                .WithMany(t => t.ChannelMessages)
                .HasForeignKey(f => f.ChannelId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<ChannelMessage>()
                .HasOne(p => p.Owner)
                .WithMany(t => t.UserMessages)
                .HasForeignKey(f => f.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
            
            
        }
    }
}
