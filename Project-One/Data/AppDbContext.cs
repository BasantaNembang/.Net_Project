using Microsoft.EntityFrameworkCore;
using Project_One.Modal;

namespace Project_One.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }



        public DbSet<Book> Books { get; set; }

    }




}
