using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ournms.Persistence;

namespace ournms.Controllers;

[Route("api/test")]
[ApiController]
public class Test(AppDbContext context) : Controller
{
    [HttpGet]
    public async Task<ActionResult<bool>> Index()
    {
        try
        {
            await context.Database.OpenConnectionAsync();
            await context.Database.CloseConnectionAsync();
            Console.WriteLine("Database connection succeeded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Database connection failed: {ex.Message}");
        }

        return true;
    }
}