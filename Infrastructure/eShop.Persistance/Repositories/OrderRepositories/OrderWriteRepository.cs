using eShop.Application.Repositories.OrderRepository;
using eShop.Domain.Entities;
using eShop.Persistance.Contexts;

namespace eShop.Persistance.Repositories.OrderRepositories;

public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
{
    public OrderWriteRepository(eShopDbContext context) : base(context)
    {
    }
}
