using MediatR;

namespace eShop.Application.Features.Queries.Order.GetOrderById;

public class GetOrderByIdQueryRequest : IRequest<GetOrderByIdQueryResponse>
{
    public Guid Id { get; set; }
}
