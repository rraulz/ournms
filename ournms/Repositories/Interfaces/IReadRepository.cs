using Ardalis.Specification;

namespace ournms.Repositories.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
{
}