using Microsoft.EntityFrameworkCore;
using Models;

namespace TicketerApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
