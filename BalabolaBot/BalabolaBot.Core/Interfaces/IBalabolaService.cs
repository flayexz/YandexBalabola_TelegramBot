using BalabolaBot.Core.Classes;

namespace BalabolaBot.Core.Interfaces;

public interface IBalabolaService
{
    public Task<string> GetBalabolaAsync(string message, BalabolaTheme theme = BalabolaTheme.Default);
}