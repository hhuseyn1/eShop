using eShop.Application.Repositories.OrderRepository;
using MediatR;

namespace eShop.Application.Features.Queries.Order.GetOrderById;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQueryRequest, GetOrderByIdQueryResponse>
{
    private readonly IOrderReadRepository _readRepository;

    public GetOrderByIdQueryHandler(IOrderReadRepository readRepository)
    {
        this._readRepository = readRepository;
    }
    
    public async Task<GetOrderByIdQueryResponse> Handle(GetOrderByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var order = await _readRepository.GetAsync(request.Id.ToString());

        return new GetOrderByIdQueryResponse() { Order = order };
    }
}