using eShop.Application.Paginations;
using eShop.Application.Repositories;
using eShop.Application.ViewModels;
using eShop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eShop.API.Controllers;

[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    [HttpGet("getAll")]
    public IActionResult GetAll([FromQuery] Pagination pagination)
    {
        try
        {
            var products = _unitOfWork.ProductReadRepository.GetAll(tracking: false);
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

    [HttpPost("Add")]
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
                var result = await _unitOfWork.ProductWriteRepository.AddAsync(product);
                if (result)
                {
                    await _unitOfWork.ProductWriteRepository.SaveChangesAsync();
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
