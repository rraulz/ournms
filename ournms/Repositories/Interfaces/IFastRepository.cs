using ournms.Entites;

namespace ournms.Repositories.Interfaces;

public interface IFastRepository<T> where T : BaseEntity
{
    public void Add(T entity);
    public Task AddRangeAsync(IEnumerable<T> entities, int batchSize = 1000);
}