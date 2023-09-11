namespace eShop.Application.Features.Queries.Customer.GetAllCustomers;

public class GetAllCustomersQueryResponse
{
    public int TotalCount { get; set; }
    public object Customers { get; set; }
}