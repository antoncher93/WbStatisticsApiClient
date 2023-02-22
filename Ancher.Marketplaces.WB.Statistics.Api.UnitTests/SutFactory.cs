using Ancher.Marketplaces.WB.Statistics.Api.UnitTests.Fakes;

namespace Ancher.Marketplaces.WB.Statistics.Api.UnitTests;

public static class SutFactory
{
    public static Sut Create()
    {
        var fakeHttpMessageHandler = new FakeHttpMessageHandler();
        
        var httpClient = new HttpClient(
            handler: fakeHttpMessageHandler)
        {
            BaseAddress = new Uri("http://testapi"),
        };
        
        return new Sut(
            statsApiClient: StatsClientFactory.Create(
                httpClient: httpClient),
            fakeHttpMessageHandler: fakeHttpMessageHandler);
    }
}