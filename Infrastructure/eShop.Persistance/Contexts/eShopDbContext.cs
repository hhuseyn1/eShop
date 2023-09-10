using eShop.Domain.Entities;
using eShop.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace eShop.Persistance.Contexts;

public class eShopDbContext : DbContext
{
    public eShopDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var datas = ChangeTracker.Entries<BaseEntity>();
        foreach (var entity in datas)
        {
            _ = entity.State switch
            {
                EntityState.Added => entity.Entity.CreatedDate = DateTime.Now,
                _ => DateTime.Now,
            };
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
