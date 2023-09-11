using eShop.Application.Repositories.OrderRepository;
using eShop.Domain.Entities;
using MediatR;

namespace eShop.Application.Features.Commands.OrderCommands.AddOrder;

public class AddOrderCommandHandler : IRequestHandler<AddOrderCommandRequest, AddOrderCommandResponse>
{
    private readonly IOrderWriteRepository _writeRepository;
    public AddOrderCommandHandler(IOrderWriteRepository writeRepository)
    {
        this._writeRepository = writeRepository;
    }

    public async Task<AddOrderCommandResponse> Handle(AddOrderCommandRequest request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            Address = request.Address,
            Description = request.Description,
            Products = request.Products,
            Customer = request.Customer,
        };
        await _writeRepository.AddAsync(order);
        await _writeRepository.SaveChangesAsync();
        return new();
    }
}
