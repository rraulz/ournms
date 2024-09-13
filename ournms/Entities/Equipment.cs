using ournms.Entites;

namespace ournms.Entities;

public class Equipment(string name, string ipAddress) : BaseEntity
{
    public string Name { get; set; } = name;
    public string IpAddress { get; set; } = ipAddress;

    public int SnmpAccessDataId { get; set; }
    public SnmpAccessData SnmpAccessData { get; set; }
    public ICollection<EquipmentStructure> Structure;
}