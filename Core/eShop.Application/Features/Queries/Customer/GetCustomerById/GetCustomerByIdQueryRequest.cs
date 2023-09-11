using MediatR;

namespace eShop.Application.Features.Queries.Customer.GetCustomersById;

public class GetCustomerByIdQueryRequest : IRequest<GetCustomerByIdQueryResponse>
{
    public Guid Id { get; set; }
}
