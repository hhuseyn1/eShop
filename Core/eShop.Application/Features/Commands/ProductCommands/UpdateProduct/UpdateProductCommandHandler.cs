using eShop.Application.Repositories;
using eShop.Application.Repositories.ProductRepository;
using MediatR;

namespace eShop.Application.Features.Commands.ProductCommands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
{
    private readonly IProductWriteRepository _writeRepository;
    private readonly IProductReadRepository _readRepository;

    public UpdateProductCommandHandler(IProductWriteRepository writeRepository, IProductReadRepository readRepository)
    {
        this._writeRepository = writeRepository;
        this._readRepository = readRepository;
    }

    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await _readRepository.GetAsync(request.Id.ToString());

        product.Name = request.Name;
        product.Description = request.Desc;
        product.Price = request.Price;
        product.Stock = request.Stock;

        _writeRepository.Update(product);
        await _writeRepository.SaveChangesAsync();

        return new();
    }
}
