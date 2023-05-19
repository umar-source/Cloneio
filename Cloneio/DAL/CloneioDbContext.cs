using Cloneio.Models;
using Microsoft.EntityFrameworkCore;

namespace Cloneio.DAL
{
    public class CloneioDbContext : DbContext
    {
        public CloneioDbContext(DbContextOptions<CloneioDbContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
    }
}
