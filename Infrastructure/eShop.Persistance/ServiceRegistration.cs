using eShop.Application.Repositories;
using eShop.Persistance.Contexts;
using eShop.Persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace eShop.Persistance;

public static class ServiceRegistration
{
    public static void AddPersistanceServices(this IServiceCollection services)
    {
        services.AddDbContext<eShopDbContext>(options => options.UseSqlServer(Configuration.ConnectionString, op => options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)), ServiceLifetime.Transient);));
        services.AddTransient<IRepository, Repository>();
    }
}
