using Ancher.Marketplaces.WB.Statistics.Api.Results;

namespace Ancher.Marketplaces.WB.Statistics.Api;

public interface IStatsApiClient : IDisposable
{
    Task<GetSalesResult> GetSalesAsync(string apiKey,
        DateTime dateFrom,
        bool flag, CancellationToken cancellationToken);
}