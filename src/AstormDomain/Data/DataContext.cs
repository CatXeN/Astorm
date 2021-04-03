using AstormDomain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AstormDomain.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Canal> Canals { get; set; }
        public DbSet<CanalMessage> CanalMessages { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
    }
}