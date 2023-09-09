using eShop.Application.Repositories.CustomerRepository;
using eShop.Domain.Entities;
using eShop.Persistance.Contexts;

namespace eShop.Persistance.Repositories.CustomerRepositories;

public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
{
    public CustomerReadRepository(eShopDbContext context) : base(context)
    {
    }
}
