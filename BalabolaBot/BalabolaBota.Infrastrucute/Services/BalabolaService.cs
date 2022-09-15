using BalabolaBot.Core.Classes;
using BalabolaBot.Core.Interfaces;

namespace BalabolaBot.Infrastrucute.Services;

public class BalabolaService : IBalabolaService
{
    public Task<string> GetBalabolaAsync(string message, BalabolaTheme theme = BalabolaTheme.Default)
    {
        throw new NotImplementedException();
    }
}