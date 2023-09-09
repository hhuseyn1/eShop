using eShop.Application.Paginations;
using eShop.Application.Repositories.ProductRepository;
using eShop.Application.ViewModels;
using eShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eShop.API.Controllers;

[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly IProductWriteRepository _productWriteRepository;

    public ProductController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
    {
        this._productReadRepository = productReadRepository;
        this._productWriteRepository = productWriteRepository;
    }

    [HttpGet("getAll")]
    public IActionResult GetAll([FromQuery] Pagination pagination)
    {
        try
        {
            //return Ok(_productReadRepository.GetAll());
            var products = _productReadRepository.GetAll(tracking: false);
            var totalCount = products.Count();
            products = products.OrderBy(p => p.CreatedDate).Skip(pagination.Size * pagination.Page)
                .Take(pagination.Size).ToList();
            return Ok(new { products, totalCount });
        }
        catch (Exception)
        {
            //Logging
            return BadRequest();
        }
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody]AddProductViewModel viewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                Product product = new()
                {
                    Id = Guid.NewGuid(),
                    Name = viewModel.Name,
                    Price = viewModel.Price,
                    Description = viewModel.Description,
                    Stock = viewModel.Stock,
                    CreatedDate = DateTime.Now
                };
                var result = await _productWriteRepository.AddAsync(product);
                if (result)
                {
                    await _productWriteRepository.SaveChangesAsync();
                    return Ok();
                }
            }
            return BadRequest(ModelState);
        }
        catch (Exception)
        {
            //Logging
            return BadRequest();
        }
    }


}
