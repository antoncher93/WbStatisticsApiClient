namespace Ancher.Marketplaces.WB.Statistics.Api.StudyTests;

public static class SutFactory
{
    public static Sut Create()
    {
        var studyApiKey = Environment.GetEnvironmentVariable("WB_STUDY_API_KEY");
        var statsApiClient = StatsClientFactory.Create();
        
        return new Sut(
            client: statsApiClient,
            studyApiKey: studyApiKey!);
    }
}