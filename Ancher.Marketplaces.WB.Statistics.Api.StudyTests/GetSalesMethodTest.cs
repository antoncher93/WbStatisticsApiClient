using System.Net;
using Ancher.Marketplaces.WB.Statistics.Api.Results;
using FluentAssertions;
using Xunit;

namespace Ancher.Marketplaces.WB.Statistics.Api.StudyTests;

public class GetSalesMethodTest
{
    [Fact]
    public async Task ReturnsOkWhenApiKeyIsValid()
    {
        var sut = SutFactory.Create();

        var result = await sut.GetSalesWithValidApiKeyAsync();

        result.Match(
                onSuccess: success => (object)success,
                onError: error => error)
            .Should()
            .BeOfType<GetSalesResult.SuccessResult>();
    }
    
    [Fact]
    public async Task ReturnsUnauthorizedWhenApiKeyIsValid()
    {
        var sut = SutFactory.Create();

        var result = await sut.GetSalesWithInvalidApiKeyAsync();

        var expectedResult = GetSalesResult.FromError(
            httpStatusCode: HttpStatusCode.Unauthorized,
            message: string.Empty);

        result.Should()
            .BeEquivalentTo(
                expectation: expectedResult,
                config: options => options
                    .Excluding(r => r.Error!.Message));
    }
}