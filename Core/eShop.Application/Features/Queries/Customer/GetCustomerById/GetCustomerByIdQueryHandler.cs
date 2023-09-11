using eShop.Application.Repositories.CustomerRepository;
using MediatR;

namespace eShop.Application.Features.Queries.Customer.GetCustomersById;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQueryRequest, GetCustomerByIdQueryResponse>
{
    private readonly ICustomerReadRepository _readRepository;

    public GetCustomerByIdQueryHandler(ICustomerReadRepository readRepository)
    {
        this._readRepository = readRepository;
    }

    public async Task<GetCustomerByIdQueryResponse> Handle(GetCustomerByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var customer = await _readRepository.GetAsync(request.Id.ToString());

        return new GetCustomerByIdQueryResponse() { Customer = customer };
    }
}