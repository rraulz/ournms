using System.ComponentModel.DataAnnotations;

namespace ournms.Entities;

public class Equipment() : BaseEntity
{
    public Equipment(int id, string name, string ipAddress, int snmpAccessDataId, SnmpAccessData snmpAccessData) : this()
    {
        Id = id;
        Name = name;
        IpAddress = ipAddress;
        SnmpAccessDataId = snmpAccessDataId;
        SnmpAccessData = snmpAccessData;
    }
    
    [Required, MaxLength(500)]
    public required string Name { get; set; }
    
    [Required, MaxLength(500)]
    public required string IpAddress { get; set; }

    [Required]
    public required int SnmpAccessDataId { get; set; }
    
    [Required]
    public required SnmpAccessData SnmpAccessData { get; set; }


    public ICollection<EquipmentStructure> Structure { get; set; }  = new List<EquipmentStructure>();
}