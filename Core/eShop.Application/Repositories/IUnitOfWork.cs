using eShop.Application.Repositories.CustomerRepository;
using eShop.Application.Repositories.OrderRepository;
using eShop.Application.Repositories.ProductRepository;

namespace eShop.Application.Repositories;

public interface IUnitOfWork
{
    ICustomerReadRepository CustomerReadRepository { get; }
    ICustomerWriteRepository CustomerWriteRepository { get; }
    IOrderReadRepository OrderReadRepository { get; }
    IOrderWriteRepository OrderWriteRepository { get; }
    IProductReadRepository ProductReadRepository { get; }
    IProductWriteRepository ProductWriteRepository { get; }
    Task<bool> SaveChangesAsync();
  
}
