using BalabolaBot.Core.Classes;
using BalabolaBot.Core.Interfaces;
using BalabolaBot.Infrastrucute.Services;

namespace BalabolaBot.Configuration;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<HttpClient>();
        services.AddSingleton(new Bot(configuration.GetRequiredSection("Key").Value!));
        services.AddScoped<IBalabolaService, BalabolaService>();
        return services;
    }
}