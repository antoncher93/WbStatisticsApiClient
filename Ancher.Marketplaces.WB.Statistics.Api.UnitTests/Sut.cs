using System.Net;
using Ancher.Marketplaces.WB.Statistics.Api.Results;
using Ancher.Marketplaces.WB.Statistics.Api.UnitTests.Fakes;

namespace Ancher.Marketplaces.WB.Statistics.Api.UnitTests;

public class Sut
{
    private readonly IStatsApiClient _statsApiClient;
    private readonly FakeHttpMessageHandler _fakeHttpMessageHandler;

    public Sut(
        IStatsApiClient statsApiClient,
        FakeHttpMessageHandler fakeHttpMessageHandler)
    {
        _statsApiClient = statsApiClient;
        _fakeHttpMessageHandler = fakeHttpMessageHandler;
    }

    public Task<GetSalesResult> GetSalesAsync(
        string apiKey,
        DateTime date,
        bool flag)
    {
        return _statsApiClient.GetSalesAsync(
            apiKey: apiKey,
            dateFrom: date,
            flag: flag,
            cancellationToken: CancellationToken.None);
    }

    public void SetupSales(List<Sale> sales)
    {
        _fakeHttpMessageHandler.SetupSales(sales);
    }

    public void SetupValidApiKey(string apiKey)
    {
        _fakeHttpMessageHandler.SetupValidApiKey(apiKey);
    }

    public void SetupSalesErrorResponse(HttpStatusCode errorStatusCode, string errorMessage)
    {
        _fakeHttpMessageHandler.SetupGetSalesResponse(errorStatusCode, errorMessage);
    }
}