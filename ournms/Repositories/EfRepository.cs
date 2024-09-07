using Ardalis.Specification.EntityFrameworkCore;
using ournms.Persistence;
using ournms.Repositories.Interfaces;

namespace ournms.Repositories;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class
{
    public EfRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}