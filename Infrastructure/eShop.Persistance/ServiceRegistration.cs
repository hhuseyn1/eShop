using eShop.Persistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using eShop.Application.Repositories.ProductRepository;
using eShop.Persistance.Repositories.ProductRepository;
using eShop.Application.Repositories.OrderRepository;
using eShop.Persistance.Repositories.CustomerRepositories;
using eShop.Persistance.Repositories.OrderRepositories;
using eShop.Application.Repositories.CustomerRepository;
using eShop.Application.Repositories;
using eShop.Persistance.Repositories;

namespace eShop.Persistance;

public static class ServiceRegistration
{
    public static void AddPersistanceServices(this IServiceCollection services)
    {
        services.AddDbContext<eShopDbContext>(options => options
        .UseSqlServer(Configuration.ConnectionString, op => options
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)), 
        ServiceLifetime.Transient);
        
        services.AddTransient<IUnitOfWork,UnitOfWork>();
    }
}
