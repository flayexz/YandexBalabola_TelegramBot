using BalabolaBot.Core.Commands;
using Telegram.Bot;

namespace BalabolaBot.Core.Classes;

public class Bot
{
    public IReadOnlyCollection<Command> Commands => commands.AsReadOnly();
    private readonly List<Command> commands;

    public readonly TelegramBotClient Client;
    
    
    public Bot(string token)
    {
        Client = new TelegramBotClient(token);
        commands = ReflectiveEnumerator.GetEnumerableOfType<Command>().ToList();
    }
}