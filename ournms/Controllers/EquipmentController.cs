using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ournms.Entites;
using ournms.Persistence;
using ournms.Repositories.Interfaces;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace ournms.Controllers;

[Route("api/equipment")]
[ApiController]
public class EquipmentController(AppDbContext context, IRepository<Equipment> equipmentRepository) : Controller
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Equipment>>> GetAllEquipment()
    {
        //return await context.EquipmentItems.ToListAsync();

        return await equipmentRepository.ListAsync();
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<Equipment>> GetEquipment(long id)
    {
        var equipmentItem = await context.EquipmentItems.FindAsync(id);

        if (equipmentItem == null) return NotFound();

        return equipmentItem;
    }

    [HttpPost]
    public async Task<ActionResult<Equipment>> PostEquipment(Equipment equipmentItem)
    {
        context.EquipmentItems.Add(equipmentItem);
        await context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEquipment), new { id = equipmentItem.Id }, equipmentItem);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> PutEquipment(long id, Equipment equipmentItem)
    {
        if (id != equipmentItem.Id) return BadRequest();

        context.Entry(equipmentItem).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EquipmentExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteEquipment(long id)
    {
        var equipmentItem = await context.EquipmentItems.FindAsync(id);
        if (equipmentItem == null) return NotFound();

        context.EquipmentItems.Remove(equipmentItem);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool EquipmentExists(long id)
    {
        return context.EquipmentItems.Any(e => e.Id == id);
    }

    // [HttpPost]
    // public async Task<Boolean> CreateEquipment()
    // {
    //     Equipment equipment = new(RandomNumberGenerator.GetInt32(0, 10000), "Equipo mandarina", RandomNumberGenerator.GetInt32(0, 10000).ToString());
    //     context.Equipment.Add(equipment);
    //     await context.SaveChangesAsync();
    //     return true;
    // }
}