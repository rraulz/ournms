using System.Diagnostics;
using Ardalis.Specification.EntityFrameworkCore;
using EFCore.BulkExtensions;
using ournms.Persistence;
using ournms.Repositories.Interfaces;

namespace ournms.Repositories;

public class OurRepository<T>(AppDbContext dbContext)
    : RepositoryBase<T>(dbContext), IReadRepositoryArd<T>, IRepositoryArd<T>, IOurRepository<T>
    where T : class
{
    public async Task AddRangeBulksAsync(IEnumerable<T> entities)
    {
        ArgumentNullException.ThrowIfNull(entities);
        
        var watch = new Stopwatch();
        watch.Start();
        var enumerable = entities.ToList();
        await using (var transaction = await dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                await dbContext.BulkInsertAsync(enumerable);
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        watch.Stop();
        Console.WriteLine($"Inserted {enumerable.Count} records in {watch.ElapsedMilliseconds} ms.");
    }
}