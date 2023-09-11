using eShop.Application.Repositories.OrderRepository;
using MediatR;

namespace eShop.Application.Features.Commands.OrderCommands.UpdateOrder;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest, UpdateOrderCommandResponse>
{
    private readonly IOrderWriteRepository _writeRepository;
    private readonly IOrderReadRepository _readRepository;

    public UpdateOrderCommandHandler(IOrderWriteRepository writeRepository, IOrderReadRepository readRepository)
    {
        this._writeRepository = writeRepository;
        this._readRepository = readRepository;
    }

    public async Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
    {
        var order = await _readRepository.GetAsync(request.Id.ToString());

        order.Description = request.Description;
        order.Customer = request.Customer;
        order.Products = request.Products;
        order.Address = request.Address;
        _writeRepository.Update(order);
        await _writeRepository.SaveChangesAsync();

        return new();
    }
}