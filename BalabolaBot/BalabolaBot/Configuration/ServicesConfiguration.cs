using BalabolaBot.Core.Classes;

namespace BalabolaBot.Configuration;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(new Bot(configuration.GetRequiredSection("Key").ToString()!));
        return services;
    }
}