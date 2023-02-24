using Ancher.Marketplaces.WB.Statistics.Api.Results;

namespace Ancher.Marketplaces.WB.Statistics.Api.StudyTests;

public class Sut
{
    private readonly IStatsApiClient _client;
    private readonly string _studyApiKey;

    public Sut(
        IStatsApiClient client,
        string studyApiKey)
    {
        _client = client;
        _studyApiKey = studyApiKey;
    }

    public async Task<GetSalesResult> GetSalesWithValidApiKeyAsync()
    {
        return await _client.GetSalesAsync(
            apiKey: _studyApiKey,
            dateFrom: DateTime.UtcNow.Date,
            flag: true,
            cancellationToken: CancellationToken.None);
    }

    public async Task<GetSalesResult> GetSalesWithInvalidApiKeyAsync()
    {
        return await _client.GetSalesAsync(
            apiKey: Guid.NewGuid().ToString(),
            dateFrom: DateTime.UtcNow.Date,
            flag: true,
            cancellationToken: CancellationToken.None);
    }
}