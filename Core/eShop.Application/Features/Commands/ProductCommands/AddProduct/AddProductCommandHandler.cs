using eShop.Application.Repositories.ProductRepository;
using eShop.Domain.Entities;
using MediatR;

namespace eShop.Application.Features.Commands.ProductCommands.AddProduct;

public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
{

    private readonly IProductWriteRepository _writeRepository;

    public AddProductCommandHandler(IProductWriteRepository writeRepository)
    {
        this._writeRepository = writeRepository;
    }

    public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Stock = request.Stock,
            CreatedDate = DateTime.Now
        };

        await _writeRepository.AddAsync(product);
        await _writeRepository.SaveChangesAsync();
        return new();

    }

}
