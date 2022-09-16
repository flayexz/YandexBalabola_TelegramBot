using BalabolaBot.Core.Commands;

namespace BalabolaBot.Infrastrucute;

public static class YandexBalabolaConstants
{
    public const string YANDEX_URL = "https://yandex.ru/";
    public const string YANDEX_LAB = YANDEX_URL + "/lab";
    public const string API = "/api";
    public const string BASE_YANDEXLAB_API_URL = YANDEX_LAB + API + "/";
    public const string GET_YANDEX_BALABOLA_TEXT = BASE_YANDEXLAB_API_URL + "yalm/text3";
    public const int YANDEX_BALABOLA_DEFAULT_FILTER = 1;

    public const string DEFAULT_BAD_QUERY_TEXT_RESPONSE =
        "Bad query! There is forbidden words in the request. Try another text";

    public const string DEFAULT_ERROR_TEXT_RESPONSE =
        "An error has occurred! May be invalid request";

    public const string DEFAULT_EMPTY_RESPONSE = "there is empty response";
}