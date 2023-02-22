using System.Globalization;
using System.Net;
using System.Text;

namespace Ancher.Marketplaces.WB.Statistics.Api.UnitTests.Fakes;

public class FakeHttpMessageHandler : HttpMessageHandler
{
    private readonly List<string?> _validApiKeys = new();
    private readonly List<Sale> _sales = new();
    
    private HttpStatusCode _getSalesStatusCode = HttpStatusCode.OK;
    private string? _getSalesResponseMessage = null;

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var isAuthorized = CheckAuthorization(request);

        if (!isAuthorized)
        {
            return this.Unauthorized();
        }

        if (request.RequestUri!.AbsolutePath.EndsWith("/api/v1/supplier/sales"))
        {
            return this.GetSalesAsync();
        }

        throw new NotSupportedException();
    }

    public void SetupValidApiKey(
        string apiKey)
    {
        _validApiKeys.Add(apiKey);
    }

    public void SetupGetSalesResponse(
        HttpStatusCode httpStatusCode,
        string message)
    {
        _getSalesStatusCode = httpStatusCode;
        _getSalesResponseMessage = message;
    }

    private Task<HttpResponseMessage> Unauthorized()
    {
        return Task.FromResult(new HttpResponseMessage(HttpStatusCode.Unauthorized));
    }

    private Task<HttpResponseMessage> GetSalesAsync()
    {

        return Task.FromResult(
            new HttpResponseMessage()
            {
                StatusCode = _getSalesStatusCode,
                Content = this.BuildSalesStringContent(),
            });
    }

    private HttpContent BuildSalesStringContent()
    {
        if (_getSalesResponseMessage != null)
        {
            return new StringContent(_getSalesResponseMessage);
        }
        
        var sb = new StringBuilder();

        sb.Append('[');

        for (int i = 0; i < _sales.Count; i++)
        {
            var sale = _sales[i];
            
            sb.Append('{');
            sb.Append($"\"date\": \"{sale.Date.ToString("s")}\",");
            sb.Append($"\"lastChangeDate\": \"{sale.LastChangeDate.ToString("s")}\",");
            sb.Append($"\"supplierArticle\": \"{sale.SupplierArticle}\",");
            sb.Append($"\"techSize\": \"{sale.TechSize}\",");
            sb.Append($"\"barcode\": \"{sale.Barcode}\",");
            sb.Append($"\"totalPrice\": {sale.TotalPrice.ToString(CultureInfo.InvariantCulture)},");
            sb.Append($"\"discountPercent\": {sale.DiscountPercent.ToString(CultureInfo.InvariantCulture)},");
            sb.Append($"\"isSupply\": {sale.IsSupply.ToString().ToLower()},");
            sb.Append($"\"isRealization\": {sale.IsRealization.ToString().ToLower()},");
            sb.Append($"\"promoCodeDiscount\": {sale.PromoCodeDiscount.ToString(CultureInfo.InvariantCulture)},");
            sb.Append($"\"warehouseName\": \"{sale.WarehouseName}\",");
            sb.Append($"\"countryName\": \"{sale.CountryName}\",");
            sb.Append($"\"oblastOkrugName\": \"{sale.OblastOkrugName}\",");
            sb.Append($"\"regionName\": \"{sale.RegionName}\",");
            sb.Append($"\"incomeID\": {sale.IncomeId},");
            sb.Append($"\"saleID\": \"{sale.Id}\",");
            sb.Append($"\"odid\": {sale.OdId},");
            sb.Append($"\"spp\": {sale.Spp.ToString(CultureInfo.InvariantCulture)},");
            sb.Append($"\"forPay\": {sale.ForPay.ToString(CultureInfo.InvariantCulture)},");
            sb.Append($"\"finishedPrice\": {sale.FinishedPrice.ToString(CultureInfo.InvariantCulture)},");
            sb.Append($"\"priceWithDisc\": {sale.PriceWithDisc.ToString(CultureInfo.InvariantCulture)},");
            sb.Append($"\"nmId\": {sale.NmId},");
            sb.Append($"\"subject\": \"{sale.Subject}\",");
            sb.Append($"\"category\": \"{sale.Category}\",");
            sb.Append($"\"brand\": \"{sale.Brand}\",");
            sb.Append($"\"IsStorno\": {sale.IsStorno},");
            sb.Append($"\"gNumber\": \"{sale.GNumber}\",");
            sb.Append($"\"srid\": \"{sale.SrId}\",");
            sb.Append($"\"sticker\": \"{sale.Sticker}\"");
            sb.Append("}");

            if (i < _sales.Count - 1)
            {
                sb.Append(',');
            }
        }

        sb.Append(']');
        
        return new StringContent(sb.ToString());
    }

    private bool CheckAuthorization(HttpRequestMessage request)
    {
        if (request.Headers.TryGetValues("Authorization", out var values))
        {
            return _validApiKeys.Contains(values.FirstOrDefault());
        }
        
        return false;
    }

    public void SetupSales(List<Sale> sales)
    {
        _sales.AddRange(sales);
    }
}