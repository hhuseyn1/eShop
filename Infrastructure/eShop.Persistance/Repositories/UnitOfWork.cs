using eShop.Application.Repositories;
using eShop.Application.Repositories.CustomerRepository;
using eShop.Application.Repositories.OrderRepository;
using eShop.Application.Repositories.ProductRepository;
using eShop.Persistance.Contexts;
using eShop.Persistance.Repositories.CustomerRepositories;
using eShop.Persistance.Repositories.OrderRepositories;
using eShop.Persistance.Repositories.ProductRepository;

namespace eShop.Persistance.Repositories;

public class UnitOfWork : IUnitOfWork
{

    private readonly eShopDbContext _context;

    public UnitOfWork(eShopDbContext context)
    {
        _context = context;
    }

    public ICustomerReadRepository CustomerReadRepository => new CustomerReadRepository(_context);

    public ICustomerWriteRepository CustomerWriteRepository => new CustomerWriteRepository(_context);

    public IOrderReadRepository OrderReadRepository => new OrderReadRepository(_context);

    public IOrderWriteRepository OrderWriteRepository => new OrderWriteRepository(_context);

    public IProductReadRepository ProductReadRepository => new ProductReadRepository(_context);

    public IProductWriteRepository ProductWriteRepository => new ProductWriteRepository(_context);

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
