using eShop.Domain.Entities;
using MediatR;

namespace eShop.Application.Features.Commands.OrderCommands.AddOrder;

public class AddOrderCommandRequest : IRequest<AddOrderCommandResponse>
{
    public string Description { get; set; }
    public string Address { get; set; }
    public ICollection<Product> Products { get; set; }
    public Customer Customer { get; set; }
}
