using System.Net;
using System.Net.Http.Json;
using System.Web;
using Ancher.Marketplaces.WB.Statistics.Api.Results;
using Microsoft.AspNetCore.WebUtilities;

namespace Ancher.Marketplaces.WB.Statistics.Api;

internal class WbStatsApiClient : IStatsApiClient
{
    private const string ApiV1SupplierSales = "/api/v1/supplier/sales";
    
    private readonly HttpClient _httpClient;

    public WbStatsApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetSalesResult> GetSalesAsync(string apiKey,
        DateTime dateFrom,
        bool flag,
        CancellationToken cancellationToken = default)
    {
       

        var query = new Dictionary<string, string>()
        {
            ["dateFrom"] = dateFrom.ToString("u"),
            ["flag"] = flag ? "1" : "0",
        };

        var uri = QueryHelpers.AddQueryString(ApiV1SupplierSales, query);
        
        var request = new HttpRequestMessage(
            method: HttpMethod.Get,
            requestUri: uri);
        
        request.Headers.Add(
            name: "Authorization",
            value: apiKey);
        
        var response = await _httpClient.SendAsync(
            request: request,
            cancellationToken: cancellationToken);
        
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
                
                var sales = await response.Content.ReadFromJsonAsync<List<Sale>>(
                    cancellationToken: cancellationToken);
                
                return GetSalesResult.FromSuccess(
                    sales: sales!);
            
            default:
                var message = await response.Content.ReadAsStringAsync(
                    cancellationToken: cancellationToken);
                
                 return GetSalesResult.FromError(
                    httpStatusCode: response.StatusCode,
                    message: message);
        }
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}