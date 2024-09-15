using System.ComponentModel.DataAnnotations;

namespace ournms.Entities;

public class SnmpAccessData() : BaseEntity
{
    public SnmpAccessData(int id, int version, string community) : this()
    {
        Id = id;
        Version = version;
        Community = community;
    }
    
    [Required] 
    public required int Version { get; init; }

    [Required, MaxLength(500)]
    public required string Community { get; init; }

    public ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();

}