using Microsoft.EntityFrameworkCore;

namespace FreakyFashionServices.Gateway.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Models.Order> Order { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
