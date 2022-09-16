using BalabolaBot.Core.Classes;
using BalabolaBot.Core.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BalabolaBot.Core.Commands;

public class BalabolCommand : Command
{
    private readonly IBalabolaService balabolaService;

    public BalabolCommand()
    {
        
    }
    
    public BalabolCommand(IBalabolaService balabolaService)
    {
        this.balabolaService = balabolaService;
    }

    public override string Name => "Balabol";

    public override async void Execute(Message message, TelegramBotClient client)
    {
        var chatId = message.Chat.Id;
        if (message.Text is null)
            await client.SendTextMessageAsync(chatId, "text message cant be null");
        var isBalabolTheme = TryParseBalabolFromMessage(message.Text!, out var theme, out var text);
        if (!isBalabolTheme) return;
        var balabol = await balabolaService.GetBalabolaAsync(text, theme);
        await client.SendTextMessageAsync(chatId, balabol);
    }

    private bool TryParseBalabolFromMessage(string message, out BalabolaTheme theme, out string text)
    {
        theme = BalabolaTheme.Default;
        text = string.Empty;

        var splittedMessage = message.Split(" ");

        switch (splittedMessage.Length)
        {
            case < 2:
                return false;
            case < 3:
                var possibleTheme = splittedMessage[2];
                if (!int.TryParse(possibleTheme, out var result)) return false;
                theme = (BalabolaTheme)result;
                break;
        }
        
        text = splittedMessage[1];
        return true;
    }
}