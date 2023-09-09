using eShop.Application.Repositories;
using eShop.Domain.Entities.Common;
using eShop.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace eShop.Persistance.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
    private readonly eShopDbContext _context;

    public WriteRepository(eShopDbContext context)
    {
        _context = context;
    }

    DbSet<T> Table => _context.Set<T>();

    public async Task<bool> AddAsync(T entity)
    {
        var entry = await Table.AddAsync(entity);
        return entry.State == EntityState.Added;
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await Table.AddRangeAsync(entities);
    }

    public bool Remove(T entity)
    {
        var entry = Table.Remove(entity);
        return entry.State == EntityState.Deleted;
    }

    public async Task<bool> RemoveAsync(string id)
    {
        T model = await Table.FindAsync(Guid.Parse(id));
        var entry = Table.Remove(model);
        return entry.State == EntityState.Deleted;
    }

    public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();


    public bool Update(T entity)
    {
        var entry = Table.Update(entity);
        return entry.State == EntityState.Modified;
    }

    public async Task<bool> UpdateAsync(string id)
    {
        T model = await Table.FindAsync(Guid.Parse(id));
        var entry = Table.Update(model);
        return entry.State == EntityState.Modified;
    }
}
