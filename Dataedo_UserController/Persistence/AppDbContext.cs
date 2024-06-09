using Dataedo_UserController.Models;
using Microsoft.EntityFrameworkCore;

namespace Dataedo_UserController.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("UsersDb");

        }
    }
}
