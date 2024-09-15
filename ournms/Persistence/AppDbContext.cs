using Microsoft.EntityFrameworkCore;
using ournms.Entities;

namespace ournms.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Equipment> EquipmentItems { get; init; }
    public DbSet<SnmpAccessData> SnmpAccessDataItems { get; init; }
    public DbSet<EquipmentStructure> EquipmentStructureItems { get; init; }
    public DbSet<Interface> Interfaces { get; init; }

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