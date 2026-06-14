using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entity;


namespace MyApp.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Employe> Employes { get; set; }

    }
}


