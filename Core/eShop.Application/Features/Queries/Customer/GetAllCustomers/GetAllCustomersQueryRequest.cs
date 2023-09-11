using MediatR;

namespace eShop.Application.Features.Queries.Customer.GetAllCustomers;

public class GetAllCustomersQueryRequest : IRequest<GetAllCustomersQueryResponse>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 5;
}
