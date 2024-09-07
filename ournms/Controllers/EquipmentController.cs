using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using ournms.Data;
using ournms.Model;

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
        Equipment equipment = new();
        equipment.Name = "Equipo mandarina";
        equipment.Id = RandomNumberGenerator.GetInt32(0, 10000);
        equipment.IP = RandomNumberGenerator.GetInt32(0, 10000).ToString();
        context.Equipment.Add(equipment);
        await context.SaveChangesAsync();
        return true;
    }
}