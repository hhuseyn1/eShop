using eShop.Application.Repositories;
using eShop.Application.Repositories.CustomerRepository;
using eShop.Domain.Entities;
using eShop.Persistance.Contexts;

namespace eShop.Persistance.Repositories.CustomerRepositories;

public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
{
    public CustomerWriteRepository(eShopDbContext context) : base(context)
    {
    }
}
