using eShop.Application.Features.Commands.ProductCommands.AddProduct;
using eShop.Application.Features.Commands.ProductCommands.UpdateProduct;
using eShop.Application.Features.Queries.Product.GetAllProducts;
using eShop.Application.Paginations;
using eShop.Application.Repositories;
using eShop.Application.ViewModels;
using eShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace eShop.API.Controllers;

[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator mediator;

    public ProductController(IUnitOfWork unitOfWork, IMediator mediator)
    {
        this._unitOfWork = unitOfWork;
        this.mediator = mediator;
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll([FromQuery] GetProductsQueryRequest request)
    {
        try
        {
            var response = mediator.Send(request);
            return Ok(response);
        }
        catch (Exception)
        {
            //Logging
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    [HttpGet("GetbyId/{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        try
        {
            var product = await _unitOfWork.ProductReadRepository.GetAsync(p => p.Id.ToString() == id);
            if (product is not null)
                return Ok(product);
            return NotFound();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] AddProductCommandRequest request)
    {
        try
        {
            if (ModelState.IsValid)
            {
                await mediator.Send(request);
                return StatusCode((int)HttpStatusCode.Created);
            }
            return BadRequest(ModelState);
        }
        catch (Exception)
        {
            //Logging
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateProductCommandRequest request)
    {
        try
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
        catch (Exception)
        {
            // logging
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Remove([FromQuery] string id)
    {
        try
        {
            var product = await _unitOfWork.ProductReadRepository.GetAsync(id);
            var data = _unitOfWork.ProductWriteRepository.Remove(product);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

}
