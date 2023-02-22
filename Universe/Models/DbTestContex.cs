using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Universe.Models;

namespace Universe.Models
{
    public class DbTestContext : IdentityDbContext<UserModel>
    {
        public DbTestContext(DbContextOptions<DbTestContext> options) : base(options) { }
        public DbSet<Video> Video { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
