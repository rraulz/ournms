using Microsoft.EntityFrameworkCore;
using ournms.Model;

namespace ournms.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Equipment> Equipment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Equipment>().ToTable("equipments");
            modelBuilder.Entity<Equipment>().HasKey(e => e.Id);
        }
    }
}