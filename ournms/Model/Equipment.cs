namespace ournms.Model;


public class Equipment(int id, string name, string ipAddress)
{

    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string IpAddress { get; set; } = ipAddress;
}

