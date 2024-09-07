using Ardalis.Specification;

namespace ournms.Repositories.Interfaces;

public interface IRepository<T> : IRepositoryBase<T> where T : class
{
}