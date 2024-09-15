using Microsoft.AspNetCore.Mvc;
using ournms_snmp.Services.Interface;
using ournms.Entities;
using ournms.Repositories;

namespace ournms.Controllers;

[Route("api/test")]
[ApiController]
public class TestController(OurRepository<Equipment> equipmentRepository, ISnmpService snmpService) : Controller
{
    [HttpGet( "{number:int}")]
    public async Task<ActionResult<bool>> TestMethod(int number)
    {
        List<Equipment> equipmentsToAdd = [];

        for (var i = 0; i < number; i++)
        {
            // equipmentsToAdd.Add(new Equipment(1, "127.0.0.1", "", null));
        }
        
        await equipmentRepository.AddRangeBulksAsync(equipmentsToAdd);
        
        
        return true;
    }
    
    [HttpGet("/api/test/second")]
    public async Task<ActionResult<bool>> TestSecondMethod()
    {
        await snmpService.DiscoverSnmpDevices();
        return true;
    }
    
    // [HttpDelete]
    // public async Task<ActionResult<bool>> DeleteTestEquipments()
    // {
    //     await equipmentRepository.DeleteRangeAsync(await equipmentRepository.ListAsync());
    //     return true;
    // }
}