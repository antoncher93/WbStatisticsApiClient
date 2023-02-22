using System.Net;
using Ancher.Marketplaces.WB.Statistics.Api.Results;
using FluentAssertions;
using Xunit;

namespace Ancher.Marketplaces.WB.Statistics.Api.UnitTests;

public class GetSalesMethodTests
{
    [Fact]
    public async Task ReturnsSalesIfTokenValid()
    {
        var sales = CreateRandomSales();
        var apiKey = Gen.RandomString();
        var sut = SutFactory.Create();
        
        sut.SetupSales(sales);
        sut.SetupValidApiKey(apiKey);

        var expectedResult = GetSalesResult.FromSuccess(sales);

        var actualResult = await sut.GetSalesAsync(
            apiKey: apiKey,
            date: Gen.RandomDateTime(),
            flag: Gen.RandomBool());

        actualResult
            .Should()
            .BeEquivalentTo(expectedResult);
    }
    
    [Fact]
    public async Task ReturnsError()
    {
        var errorStatusCode = HttpStatusCode.Unauthorized;
        var errorMessage = Gen.RandomString();
        var apiKey = Gen.RandomString();
        var sut = SutFactory.Create();
        
        sut.SetupValidApiKey(apiKey);

        sut.SetupSalesErrorResponse(errorStatusCode, errorMessage);

        var expectedResult = GetSalesResult.FromError(
            httpStatusCode: errorStatusCode,
            message: errorMessage);

        var actualResult = await sut.GetSalesAsync(
            apiKey: apiKey,
            date: Gen.RandomDateTime(),
            flag: Gen.RandomBool());

        actualResult
            .Should()
            .BeEquivalentTo(expectedResult);
    }

    private static List<Sale> CreateRandomSales()
    {
        return Gen.ListOfValues(RandomSale);
    }

    private static Sale RandomSale()
    {
        return Sale.Create(
            date: Gen.RandomDateTime(),
            lastChangeDate: Gen.RandomDateTime(),
            supplierArticle: Gen.RandomString(),
            techSize: Gen.RandomString(),
            barcode: Gen.RandomString(),
            totalPrice: Gen.RandomDecimal(),
            discountPercent: Gen.RandomDecimal(),
            isSupply: Gen.RandomBool(),
            isRealization: Gen.RandomBool(),
            promoCodeDiscount: Gen.RandomDouble(),
            warehouseName: Gen.RandomString(),
            countryName: Gen.RandomString(),
            oblastOkrugName: Gen.RandomString(),
            regionName: Gen.RandomString(),
            incomeId: Gen.RandomInt(),
            saleId: Gen.RandomString(),
            odId: Gen.RandomInt(),
            spp: Gen.RandomDecimal(),
            forPay: Gen.RandomDecimal(),
            finishedPrice: Gen.RandomDecimal(),
            priceWithDisc: Gen.RandomDecimal(),
            nmId: Gen.RandomInt(),
            subject: Gen.RandomString(),
            category: Gen.RandomString(),
            brand: Gen.RandomString(),
            isStorno: Gen.RandomInt(0, 1),
            sticker: Gen.RandomString(),
            srId: Gen.RandomString(),
            gNumber: Gen.RandomString());
    }
}