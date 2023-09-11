using MediatR;

namespace eShop.Application.Features.Commands.CustomerCommands.AddCustomer;

public class AddCustomerCommandRequest : IRequest<AddCustomerCommandResponse>
{
    public string Name { get; set; }

}