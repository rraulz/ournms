using Microsoft.EntityFrameworkCore;
using ournms.Entites;

namespace ournms.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Equipment> EquipmentItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Equipment>().ToTable("equipments");
        modelBuilder.Entity<Equipment>().HasKey(e => e.Id);
    }
}