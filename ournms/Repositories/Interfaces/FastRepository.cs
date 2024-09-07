using System.Diagnostics;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using ournms.Entites;
using ournms.Persistence;

namespace ournms.Repositories.Interfaces;

public class FastRepository<T>(AppDbContext context) : IFastRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public void Add(T entity)
    {
        _dbSet.Add(entity);   
        _context.SaveChanges(); 
    }
    
    public async Task AddRangeAsync(IEnumerable<T> entities, int batchSize = 100000)
    {
        if (entities == null) throw new ArgumentNullException(nameof(entities));
        
        
        Stopwatch time2 = Stopwatch.StartNew();
        await test2(entities);
        time2.Stop();
        Console.WriteLine($"Inserted {entities.Count()} records in {time2.ElapsedMilliseconds} ms.");
    }

    
    private async Task test2(IEnumerable<T> entities)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                await _context.BulkInsertAsync(entities.ToList());
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
    

}