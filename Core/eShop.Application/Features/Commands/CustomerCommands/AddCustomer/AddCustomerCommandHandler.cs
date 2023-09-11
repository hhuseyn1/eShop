using eShop.Application.Repositories.CustomerRepository;
using eShop.Domain.Entities;
using MediatR;

namespace eShop.Application.Features.Commands.CustomerCommands.AddCustomer;

public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommandRequest, AddCustomerCommandResponse>
{
    private readonly ICustomerWriteRepository _writeRepository;
    public AddCustomerCommandHandler(ICustomerWriteRepository writeRepository)
    {
        this._writeRepository = writeRepository;
    }

    public async Task<AddCustomerCommandResponse> Handle(AddCustomerCommandRequest request, CancellationToken cancellationToken)
    {
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
        };

        await _writeRepository.AddAsync(customer);
        await _writeRepository.SaveChangesAsync();
        return new();
    }
}
