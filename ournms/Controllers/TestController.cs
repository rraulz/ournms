using System.Runtime.InteropServices.JavaScript;
using Ardalis.Specification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ournms_snmp.Services.Interface;
using ournms.Entites;
using ournms.Persistence;
using ournms.Repositories.Interfaces;

namespace ournms.Controllers;

[Route("api/test")]
[ApiController]
public class TestController(FastRepository<Equipment> equipmentRepository, ISnmpService snmpService) : Controller
{
    [HttpGet( "{number:int}")]
    public async Task<ActionResult<bool>> TestMethod(int number)
    {
        List<Equipment> equipmentsToAdd = new();

        for (int i = 0; i < number; i++)
        {
            equipmentsToAdd.Add(new Equipment("Test", "127.0.0.1"));
        }
        
        await equipmentRepository.AddRangeAsync(equipmentsToAdd);

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