using eShop.Application.Features.Commands.CustomerCommands.AddCustomer;
using eShop.Application.Features.Commands.CustomerCommands.UpdateCustomer;
using eShop.Application.Features.Queries.Customer.GetCustomersById;
using eShop.Application.Repositories.CustomerRepository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace eShop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerReadRepository customerReadRepository;
    private readonly ICustomerWriteRepository customerWriteRepository;
    private readonly IMediator mediator;

    public CustomerController(ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository, IMediator mediator)
    {
        this.customerReadRepository = customerReadRepository;
        this.customerWriteRepository = customerWriteRepository;
        this.mediator = mediator;
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(Guid customerId)
    {
        try
        {
            var request = new GetCustomerByIdQueryRequest { Id = customerId };
            var customer = await mediator.Send(request);

            if (customer == null)
            {
                return NotFound("Customer not found.");
            }

            return Ok(customer);
        }
        catch (Exception)
        {
            // Logging
            return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
        }
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll([FromQuery] GetCustomerByIdQueryRequest request)
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

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] AddCustomerCommandRequest request)
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
    public async Task<IActionResult> Update([FromBody] UpdateCustomerCommandRequest request)
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
