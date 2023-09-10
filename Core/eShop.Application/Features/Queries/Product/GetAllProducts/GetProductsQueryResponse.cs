namespace eShop.Application.Features.Queries.Product.GetAllProducts;

public class GetProductsQueryResponse
{
    public int TotalCount { get; set; }
    public object Products { get; set; }
}