using ournms.Entites;

namespace ournms.Entities;

public class EquipmentStructure : BaseEntity
{
    public int EquipmentId { get; set; }
    public Equipment Equipment { get; set; }
}