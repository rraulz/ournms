using System.Data.Entity;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using ournms.Model;
using ournms.Persistence;

namespace ournms.Controllers;

[Route("api/equipment")]
[ApiController]
public class EquipmentController(AppDbContext context) : Controller
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Equipment>>> GetEquipmentEntity()
    {
        return await context.Equipment.ToListAsync();
    }
    
    
    [HttpPost]
    public async Task<Boolean> CreateEquipment()
    {
        Equipment equipment = new(RandomNumberGenerator.GetInt32(0, 10000), "Equipo mandarina", RandomNumberGenerator.GetInt32(0, 10000).ToString());
        context.Equipment.Add(equipment);
        await context.SaveChangesAsync();
        return true;
    }
}