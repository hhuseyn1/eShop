using eShop.Application.Repositories;
using eShop.Domain.Entities.Common;
using eShop.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eShop.Persistance.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly eShopDbContext _context;

    public ReadRepository(eShopDbContext context)
    {
        this._context = context;
    }

    DbSet<T> Table => _context.Set<T>();

    public IEnumerable<T?> GetAll(bool tracking = true)
    {
        if (tracking) return Table.ToList();
        return Table.AsNoTracking().ToList();
    }

    public async Task<T?> GetAsync(string id) => await Table.FindAsync(Guid.Parse(id));

    public async Task<T?> GetAsync(Expression<Func<T, bool>> expression) => await Table.FirstOrDefaultAsync(expression);

    public IEnumerable<T?> GetWhere(Expression<Func<T, bool>> expression) => Table.Where(expression);

}   