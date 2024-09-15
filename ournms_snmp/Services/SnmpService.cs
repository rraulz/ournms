using System.Net;
using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;
using ournms_snmp.Services.Interface;

namespace ournms_snmp.Services;

public class SnmpService : ISnmpService
{
    public async Task DiscoverSnmpDevices()
    {
       Console.WriteLine("Discovering Snmp Devices");

       await DiscoverAsync();
    }
    
    
    private static async Task DiscoverAsync()
    {

        var discoverer = new Discoverer();
        discoverer.AgentFound += DiscovererAgentFound;
        Console.WriteLine("v1 discovery");
        await discoverer.DiscoverAsync(VersionCode.V1, new IPEndPoint(IPAddress.Broadcast, 161), new OctetString("public"), 6000);
        Console.WriteLine("v2 discovery");
        await discoverer.DiscoverAsync(VersionCode.V2, new IPEndPoint(IPAddress.Broadcast, 161), new OctetString("public"), 6000);
        Console.WriteLine("v3 discovery");
        await discoverer.DiscoverAsync(VersionCode.V3, new IPEndPoint(IPAddress.Broadcast, 161), null, 6000);
    }

    private static void DiscovererAgentFound(object? sender, AgentFoundEventArgs e)
    {
        Console.WriteLine("{0} announces {1}", e.Agent, (e.Variable == null ? "it supports v3" : e.Variable.Data.ToString()));
    }
}