using eShop.Domain.Entities.Common;


namespace eShop.Application.Repositories;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
{
    Task<bool> AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);

    bool Update(T entity);
    bool Remove(T entity);

    Task<bool> RemoveAsync(string id);
    Task<bool> UpdateAsync(string id);

    Task<int> SaveChangesAsync();
}
