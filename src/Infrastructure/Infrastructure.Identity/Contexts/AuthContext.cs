using Infrastructure.Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity.Contexts
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
    }
}