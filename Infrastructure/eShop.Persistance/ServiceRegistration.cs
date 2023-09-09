using eShop.Persistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using eShop.Application.Repositories.ProductRepository;
using eShop.Persistance.Repositories.ProductRepository;
using eShop.Application.Repositories.OrderRepository;
using eShop.Persistance.Repositories.CustomerRepositories;
using eShop.Persistance.Repositories.OrderRepositories;
using eShop.Application.Repositories.CustomerRepository;

namespace eShop.Persistance;

public static class ServiceRegistration
{
    public static void AddPersistanceServices(this IServiceCollection services)
    {
        services.AddDbContext<eShopDbContext>(options => options
        .UseSqlServer(Configuration.ConnectionString, op => options
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)), 
        ServiceLifetime.Transient);
        
        services.AddTransient<IProductReadRepository,ProductReadRepository>();
        services.AddTransient<IProductReadRepository,ProductReadRepository>();

        services.AddTransient<IOrderReadRepository, OrderReadRepository>();
        services.AddTransient<IOrderReadRepository, OrderReadRepository>();

        services.AddTransient<ICustomerReadRepository, CustomerReadRepository>();
        services.AddTransient<ICustomerReadRepository, CustomerReadRepository>();
    }
}
