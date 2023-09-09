using eShop.Application.Repositories.ProductRepository;
using eShop.Domain.Entities;
using eShop.Persistance.Contexts;

namespace eShop.Persistance.Repositories.ProductRepository;

public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
{
    public ProductWriteRepository(eShopDbContext context) : base(context)
    {

    }
}