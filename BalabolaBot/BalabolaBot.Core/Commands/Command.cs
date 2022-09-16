using Telegram.Bot;
using Telegram.Bot.Types;

namespace BalabolaBot.Core.Commands;

public abstract class Command
{
    public abstract string Name { get; }
    public abstract void Execute(Message message, TelegramBotClient client);
    public bool Contains(string command) => command.Contains(Name);
}