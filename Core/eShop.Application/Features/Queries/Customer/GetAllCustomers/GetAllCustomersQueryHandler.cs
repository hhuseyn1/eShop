using eShop.Application.Repositories.CustomerRepository;
using MediatR;

namespace eShop.Application.Features.Queries.Customer.GetAllCustomers;

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQueryRequest, GetAllCustomersQueryResponse>
{
    private readonly ICustomerReadRepository _readRepository;

    public GetAllCustomersQueryHandler(ICustomerReadRepository readRepository)
    {
        this._readRepository = readRepository;
    }

    public async Task<GetAllCustomersQueryResponse> Handle(GetAllCustomersQueryRequest request, CancellationToken cancellationToken)
    {
        var customers = _readRepository.GetAll(tracking: false);
        var totalCount = customers.Count();

        var selecetedCustomers = customers
                    .OrderBy(p => p.CreatedDate)
                    .Skip(request.Size * request.Page)
                    .Take(request.Size)
                    .Select(p => new
                    {
                        p.Name,
                    });

        return new() { Customers = selecetedCustomers, TotalCount = totalCount };
    }
}
