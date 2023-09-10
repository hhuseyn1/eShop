using MediatR;

namespace eShop.Application.Features.Queries.Product.GetAllProducts;

public class GetProductsQueryRequest : IRequest<GetProductsQueryResponse>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 5;
}
