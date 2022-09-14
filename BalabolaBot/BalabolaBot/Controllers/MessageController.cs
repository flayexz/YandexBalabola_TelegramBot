using BalabolaBot.Core.Classes;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace BalabolaBot.Controllers;

[ApiController]
public class MessageController : Controller
{
    private readonly Bot bot;

    public MessageController(Bot bot)
    {
        this.bot = bot;
    }

    [Route(@"api/message/update")]
    public OkResult Update(Update update)
    {
        var commands = bot.Commands;
        var message = update.Message;
        if (message is null) return Ok();
        var client = bot.Client;
        var text = message.Text;
        if (string.IsNullOrEmpty(text)) return Ok();
        
        foreach (var command in commands)
        {
            if (!command.Contains(text)) continue;
            command.Execute(message, client);
            break;
        }

        return Ok();
    }
}