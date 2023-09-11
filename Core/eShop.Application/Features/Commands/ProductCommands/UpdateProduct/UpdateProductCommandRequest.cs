using MediatR;

namespace eShop.Application.Features.Commands.ProductCommands.UpdateProduct;

public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
    public float Price { get; set; }
    public int Stock { get; set; }
}