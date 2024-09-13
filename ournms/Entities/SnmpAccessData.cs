using ournms.Entites;

namespace ournms.Entities;

public class SnmpAccessData : BaseEntity
{
    public int version { get; set; }
    public int community { get; set; }
    public ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();

}