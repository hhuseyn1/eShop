using eShop.Domain.Entities.Common;

namespace eShop.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
    public ICollection<Order> Orders { get; set; }
}
