using eShop.Application.Repositories.CustomerRepository;
using MediatR;

namespace eShop.Application.Features.Commands.CustomerCommands.UpdateCustomer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommandRequest, UpdateCustomerCommandResponse>
{
    private readonly ICustomerWriteRepository _writeRepository;
    private readonly ICustomerReadRepository _readRepository;

    public UpdateCustomerCommandHandler(ICustomerWriteRepository writeRepository, ICustomerReadRepository readRepository)
    {
        this._writeRepository = writeRepository;
        this._readRepository = readRepository;
    }

    public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await _readRepository.GetAsync(request.Id.ToString());

        product.Name = request.Name;

        _writeRepository.Update(product);
        await _writeRepository.SaveChangesAsync();

        return new();
    }
}
