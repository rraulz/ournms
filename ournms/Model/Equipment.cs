namespace ournms.Model;


public class Equipment(long id, string name, string ipAddress)
{

    public long Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string IpAddress { get; set; } = ipAddress;
}

