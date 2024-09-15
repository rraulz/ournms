using System.ComponentModel.DataAnnotations;

namespace ournms.Entities;

public class Interface() : EquipmentStructure
{
    public Interface(int id, Equipment equipment, string name, long index) : this()
    {
        Id = id;
        Equipment = equipment;
        EquipmentId = equipment.Id;
        Name = name;
        Index = index;
    }
    
    
    [Required, MaxLength(500)] 
    public required string Name { get; init; }
    
    [Required]
    public required long Index { get; init; }
    
}