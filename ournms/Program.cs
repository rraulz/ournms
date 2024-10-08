using Microsoft.EntityFrameworkCore;
using ournms_snmp.Services;
using ournms_snmp.Services.Interface;
using ournms.Persistence;
using ournms.Repositories;
using ournms.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddDbContextPool<AppDbContext>(options =>
    options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IReadRepositoryArd<>), typeof(OurRepository<>)); //Ardalis
builder.Services.AddScoped(typeof(IRepositoryArd<>), typeof(OurRepository<>)); //Ardalis
builder.Services.AddScoped(typeof(OurRepository<>));  

builder.Services.AddScoped<ISnmpService, SnmpService>();  

var app = builder.Build();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();