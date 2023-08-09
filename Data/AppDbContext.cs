using Microsoft.EntityFrameworkCore;
using testapp.Models;

namespace testapp.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> ptions ):base(ptions)
        {

        }

        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Students> Students { get; set; } 

    }
}
