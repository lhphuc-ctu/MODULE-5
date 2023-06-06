using EFCORE.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCORE.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }
    }
}
