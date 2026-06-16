using Auth_Project.Entity;
using Microsoft.EntityFrameworkCore;

namespace Auth_Project.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
      public DbSet<User> Users { get; set; }
      public DbSet<RefreshToken> RefreshTokens { get; set; }

    }
}











