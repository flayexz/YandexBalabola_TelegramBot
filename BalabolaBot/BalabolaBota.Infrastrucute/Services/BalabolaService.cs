using System.Net.Http.Json;
using BalabolaBot.Core.Classes;
using BalabolaBot.Core.Interfaces;
using BalabolaBot.Infrastrucute.DTO;

namespace BalabolaBot.Infrastrucute.Services;

public class BalabolaService : IBalabolaService
{
    private readonly HttpClient httpClient;

    public BalabolaService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<string> GetBalabolaAsync(string message, BalabolaTheme theme = BalabolaTheme.Default)
    {
        var data = new BalabolaRequestDto(YandexBalabolaConstants.YANDEX_BALABOLA_DEFAULT_FILTER, (int)theme, message);
        var response = await httpClient.PostAsJsonAsync(YandexBalabolaConstants.GET_YANDEX_BALABOLA_TEXT, data);
        var balabolaResponse = await response.Content.ReadFromJsonAsync<BalabolaResponseDto>();
        if (balabolaResponse is null) return YandexBalabolaConstants.DEFAULT_EMPTY_RESPONSE;
        return GetBalabolaFromResponse(balabolaResponse);
    }

    private string GetBalabolaFromResponse(BalabolaResponseDto response)
    {
        if (response.BadQuery != 0)
        {
            return YandexBalabolaConstants.DEFAULT_BAD_QUERY_TEXT_RESPONSE;
        }

        if (response.Error != 0)
        {
            return YandexBalabolaConstants.DEFAULT_ERROR_TEXT_RESPONSE;
        }

        return response.Text;
    }
}