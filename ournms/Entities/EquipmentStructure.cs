using System.ComponentModel.DataAnnotations;

namespace ournms.Entities;

public class EquipmentStructure() : BaseEntity
{
    public EquipmentStructure(int id, Equipment equipment) : this()
    {
        Id = id;
        EquipmentId = equipment.Id;
        Equipment = equipment;
    }
    
    [Required] 
    public required int EquipmentId { get; init; } 
    
    [Required] 
    public required Equipment Equipment { get; init; } 
}