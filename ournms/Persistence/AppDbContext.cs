using Microsoft.EntityFrameworkCore;
using ournms.Entites;
using ournms.Entities;

namespace ournms.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Equipment> EquipmentItems { get; set; }
    public DbSet<SnmpAccessData> SnmpAccessDataItems { get; set; }
    public DbSet<EquipmentStructure> EquipmentStructureItems { get; set; }
    public DbSet<Interface> Interfaces { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Equipment>().HasKey(e => e.Id);
        
        modelBuilder.Entity<Equipment>()
            .HasOne(e => e.SnmpAccessData)
            .WithMany(e => e.Equipments)
            .HasForeignKey(e => e.SnmpAccessDataId);

        modelBuilder.Entity<Equipment>()
            .HasMany(e => e.Structure)
            .WithOne(e => e.Equipment)
            .HasForeignKey(e => e.EquipmentId);
        
        modelBuilder.Entity<SnmpAccessData>().HasKey(e => e.Id);
        
        modelBuilder.Entity<EquipmentStructure>().HasKey(e => e.Id);

        modelBuilder.Entity<EquipmentStructure>()
            .HasDiscriminator<string>("strucutre_type")
            .HasValue<EquipmentStructure>("equipment_structure")
            .HasValue<Interface>("interface");
    }
}