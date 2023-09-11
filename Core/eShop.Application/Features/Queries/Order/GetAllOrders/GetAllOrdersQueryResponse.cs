using MediatR;

namespace eShop.Application.Features.Queries.Order.GetAllOrders;

public class GetAllOrdersQueryResponse
{
    public int TotalCount { get; set; }
    public object Orders { get; set; }
}
