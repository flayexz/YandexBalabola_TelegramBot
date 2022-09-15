using BalabolaBot.Core.Classes;
using Telegram.Bot;

namespace BalabolaBot.Configuration;

public static class ConfigureBot
{
    public static async Task ConfigureBotAsync(this IServiceProvider serviceProvider,
        IConfiguration configuration)
    {
        var bot = serviceProvider.GetRequiredService<Bot>();
        await bot.Client.SetWebhookAsync(configuration.GetRequiredSection("hookUrl").Value!);
    }
}