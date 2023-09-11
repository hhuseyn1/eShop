using eShop.Application.Features.Commands.OrderCommands.AddOrder;
using eShop.Application.Features.Commands.OrderCommands.UpdateOrder;
using eShop.Application.Features.Queries.Order.GetAllOrders;
using eShop.Application.Features.Queries.Order.GetOrderById;
using eShop.Application.Repositories.OrderRepository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace eShop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderReadRepository _readRepository;
    private readonly IOrderWriteRepository _writeRepository;
    private readonly IMediator mediator;

    public OrderController(IOrderReadRepository readRepository, IOrderWriteRepository writeRepository, IMediator mediator)
    {
        this._readRepository = readRepository;
        this._writeRepository = writeRepository;
        this.mediator = mediator;
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll([FromQuery] GetAllOrdersQueryRequest request)
    {
        try
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
        catch (Exception)
        {
            // Logging
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(Guid orderId)
    {
        try
        {
            var request = new GetOrderByIdQueryRequest { Id = orderId };
            var order = await mediator.Send(request);

            if (order == null)
            {
                return NotFound("Order not found.");
            }

            return Ok(order);
        }
        catch (Exception)
        {
            // Logging
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
        }
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] AddOrderCommandRequest request)
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
            // Logging
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }


    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateOrderCommandRequest request)
    {
        try
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
        catch (Exception)
        {
            // Logging
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }

}
