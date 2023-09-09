using eShop.Domain.Entities.Common;
using System.Linq.Expressions;

namespace eShop.Application.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
    IEnumerable<T> GetAll(bool tracking = true);
    IEnumerable<T> GetWhere(Expression<Func<T,bool>> expression);
    Task<T> GetAsync(string id);
    Task<T> GetAsync(Expression<Func<T,bool>> expression);
}
