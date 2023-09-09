using eShop.Application.Repositories.ProductRepository;
using eShop.Domain.Entities;
using eShop.Persistance.Contexts;

namespace eShop.Persistance.Repositories.ProductRepository;

public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
{
    public ProductReadRepository(eShopDbContext context) : base(context)
    {

    }
}
