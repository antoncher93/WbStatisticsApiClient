using System.Text.Json.Serialization;

namespace Ancher.Marketplaces.WB.Statistics.Api;

public class Sale
{
    public static Sale Create(
        DateTime date,
        DateTime lastChangeDate,
        string supplierArticle,
        string techSize,
        string barcode,
        decimal totalPrice,
        decimal discountPercent,
        bool isSupply,
        bool isRealization,
        double promoCodeDiscount,
        string warehouseName,
        string countryName,
        string oblastOkrugName,
        string regionName,
        int incomeId,
        string saleId,
        int odId,
        decimal spp,
        decimal forPay,
        decimal finishedPrice,
        decimal priceWithDisc,
        int nmId,
        string subject,
        string category,
        string brand,
        int isStorno,
        string sticker,
        string srId,
        string gNumber)
    {
        return new Sale()
        {
            Date = date,
            LastChangeDate = lastChangeDate,
            SupplierArticle = supplierArticle,
            TechSize = techSize,
            Barcode = barcode,
            TotalPrice = totalPrice,
            DiscountPercent = discountPercent,
            IsSupply = isSupply,
            IsRealization = isRealization,
            PromoCodeDiscount = promoCodeDiscount,
            WarehouseName = warehouseName,
            CountryName = countryName,
            OblastOkrugName = oblastOkrugName,
            RegionName = regionName,
            IncomeId = incomeId,
            Id = saleId,
            OdId = odId,
            Spp = spp,
            ForPay = forPay,
            FinishedPrice = finishedPrice,
            PriceWithDisc = priceWithDisc,
            NmId = nmId,
            Subject = subject,
            Category = category,
            Brand = brand,
            IsStorno = isStorno,
            Sticker = sticker,
            SrId = srId,
            GNumber = gNumber,
        };
    }

    public DateTime Date { get; set; }
    
    public DateTime LastChangeDate { get; set; }

    public string SupplierArticle { get; set; }
    
    public string TechSize { get; set; }
    
    public string Barcode { get; set; }
    
    public decimal TotalPrice { get; set; }
    
    public decimal DiscountPercent { get; set; }
    
    public bool IsSupply { get; set; }
    
    public bool IsRealization { get; set; }
    
    public double PromoCodeDiscount { get; set; }
    
    public string WarehouseName { get; set; }
    
    public string CountryName { get; set; }
    
    public string OblastOkrugName { get; set; }
    
    public string RegionName { get; set; }
    
    public int IncomeId { get; set; }
    
    [JsonPropertyName("saleID")]
    public string Id { get; set; }
    
    public int OdId { get; set; }
    
    public decimal Spp { get; set; }
    
    public decimal ForPay { get; set; }
    
    public decimal FinishedPrice { get; set; }
    
    public decimal PriceWithDisc { get; set; }
    
    public int NmId { get; set; }
    
    public string Subject { get; set; }
    
    public string Category { get; set; }
    
    public string Brand { get; set; }
    
    public int IsStorno { get; set; }
    
    public string Sticker { get; set; }
    
    public string SrId { get; set; }
    
    public string GNumber { get; set; }
}