using eShop.Persistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
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
