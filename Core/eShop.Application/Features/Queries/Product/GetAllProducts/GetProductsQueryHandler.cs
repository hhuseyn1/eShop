using eShop.Application.Repositories.ProductRepository;
using MediatR;

namespace eShop.Application.Features.Queries.Product.GetAllProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, GetProductsQueryResponse>
{
    private readonly IProductReadRepository _readRepository;

    public GetProductsQueryHandler(IProductReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<GetProductsQueryResponse> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var products = _readRepository.GetAll(tracking: false);
        var totalCount = products.Count();

        var selectedProducts = products.OrderBy(p => p.CreatedDate).Skip(request.Page * request.Size)
            .Take(request.Size).Select(p => new {
               p.Name,
                p.Price,
                p.Description,
                p.Stock
            });

        return  new() { Products = selectedProducts , TotalCount = totalCount} ;
    }
}
