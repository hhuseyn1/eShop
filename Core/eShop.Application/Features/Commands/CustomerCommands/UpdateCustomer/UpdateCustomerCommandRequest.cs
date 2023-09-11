using MediatR;

namespace eShop.Application.Features.Commands.CustomerCommands.UpdateCustomer;

public class UpdateCustomerCommandRequest : IRequest<UpdateCustomerCommandResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
