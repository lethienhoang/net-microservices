using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Platform> Platforms { get; set; }
    }
}