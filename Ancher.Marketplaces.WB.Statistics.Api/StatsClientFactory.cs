namespace Ancher.Marketplaces.WB.Statistics.Api;

public static class StatsClientFactory
{
    public static IStatsApiClient Create(
        HttpClient? httpClient = default)
    {
        httpClient ??= new HttpClient();
        httpClient.BaseAddress = new Uri("https://statistics-api.wildberries.ru");

        return new WbStatsApiClient(
            httpClient: httpClient);
    }
}