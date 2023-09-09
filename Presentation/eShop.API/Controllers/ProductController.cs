using eShop.Application.Repositories.ProductRepository;
using eShop.Persistance.Repositories.ProductRepository;
using Microsoft.AspNetCore.Mvc;

namespace eShop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;

    public ProductController(IProductReadRepository productReadRepository,IProductWriteRepository productWriteRepository)
    {
        this._productReadRepository = productReadRepository;
        this._productWriteRepository = productWriteRepository;
    }

    
}
