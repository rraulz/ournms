namespace ournms.Repositories.Interfaces;

public interface IOurRepository<in T> where T : class
{
    public Task AddRangeBulksAsync(IEnumerable<T> entities);
}