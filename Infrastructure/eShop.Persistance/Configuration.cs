using Microsoft.Extensions.Configuration;

namespace eShop.Persistance;

public static class Configuration
{
    public static string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/eShop.API"));
            configurationManager.AddJsonFile("appsettings.json");
            return configurationManager.GetConnectionString("step");
        }
    }
}
