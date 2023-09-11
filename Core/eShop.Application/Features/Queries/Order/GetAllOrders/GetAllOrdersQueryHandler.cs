using eShop.Application.Repositories.OrderRepository;
using MediatR;

namespace eShop.Application.Features.Queries.Order.GetAllOrders;

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQueryRequest, GetAllOrdersQueryResponse>
{
    private readonly IOrderReadRepository _readRepository;

    public GetAllOrdersQueryHandler(IOrderReadRepository readRepository)
    {
        this._readRepository = readRepository;
    }

    public async Task<GetAllOrdersQueryResponse> Handle(GetAllOrdersQueryRequest request, CancellationToken cancellationToken)
    {
        var orders = _readRepository.GetAll(tracking: false);
        var totalCount = orders.Count();

        var selecetedOrders = orders
                    .OrderBy(p => p.CreatedDate)
                    .Skip(request.Size * request.Page)
                    .Take(request.Size)
                    .Select(p => new
                    {
                        p.Address,
                        p.Description,
                        p.Customer,
                        p.Products
                    });

        return new() { Orders = selecetedOrders, TotalCount = totalCount };
    }
}
