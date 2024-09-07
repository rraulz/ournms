namespace ournms.Entites;

public class Equipment(string name, string ipAddress) : BaseEntity
{
    public string Name { get; set; } = name;
    public string IpAddress { get; set; } = ipAddress;
}