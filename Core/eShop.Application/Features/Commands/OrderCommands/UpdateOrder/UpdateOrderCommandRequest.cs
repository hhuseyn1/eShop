using eShop.Domain.Entities;
using MediatR;

namespace eShop.Application.Features.Commands.OrderCommands.UpdateOrder;

public class UpdateOrderCommandRequest : IRequest<UpdateOrderCommandResponse>
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public ICollection<Product> Products { get; set; }
    public Customer Customer { get; set; }
}