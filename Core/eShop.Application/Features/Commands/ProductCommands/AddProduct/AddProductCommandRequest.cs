using MediatR;

namespace eShop.Application.Features.Commands.ProductCommands.AddProduct;

public class AddProductCommandRequest : IRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public int Stock { get; set; }
}
