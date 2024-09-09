using System.Diagnostics;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using ournms.Entites;
using ournms.Persistence;

namespace ournms.Repositories.Interfaces;

public class FastRepository<T>(AppDbContext context, IServiceProvider serviceProvider) : IFastRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    public void Add(T entity)
    {
        _dbSet.Add(entity);   
        _context.SaveChanges(); 
    }
    
    public async Task AddRangeAsync(IEnumerable<T> entities, int batchSize = 100000)
    {
        if (entities == null) throw new ArgumentNullException(nameof(entities));
        
        Stopwatch time1 = Stopwatch.StartNew();
        await test2(entities);
        time1.Stop();
        Console.WriteLine($"Inserted {entities.Count()} records in {time1.ElapsedMilliseconds} ms.");
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
    
    private async Task test3(IEnumerable<T> entities, int batchSize = 100000)
    {
        var entityList = entities.ToList();

        // Partition the entities into smaller batches
        var batches = entityList
            .Select((entity, index) => new { entity, index })
            .GroupBy(x => x.index / batchSize)
            .Select(g => g.Select(x => x.entity).ToList())
            .ToList();

        await Parallel.ForEachAsync(batches, async (batch, cancellationToken) =>
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite("Data Source=SQLLiteDatabase.db")
                .Options;

            
                using (var context = new AppDbContext(options))
                using (var transaction = await context.Database.BeginTransactionAsync())
                {
                    Console.WriteLine($"Executing batch: {context.ContextId}");
                    try
                    {
                        await context.BulkInsertAsync(batch);
                        await transaction.CommitAsync();
                    }
                    catch
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }
                }
        });
    }
}