namespace Ancher.Marketplaces.WB.Statistics.Api.UnitTests;

public static class Gen
{
    public static string RandomString()
    {
        return Guid.NewGuid().ToString();
    }

    public static double RandomDouble()
    {
        return new Random().NextDouble();
    }

    public static decimal RandomDecimal()
    {
        return (decimal)(new Random().NextDouble());
    }
    
    public static long RandomLong()
    {
        return new Random().Next();
    }
    
    public static int RandomInt()
    {
        return new Random().Next();
    }
    
    public static int RandomInt(int min, int max)
    {
        return new Random().Next(min, max);
    }

    public static DateTime RandomDateTime()
    {
        var utcNow = DateTime.UtcNow;
        return new DateTime(utcNow.Year, utcNow.Month, utcNow.Day, utcNow.Hour, utcNow.Minute, utcNow.Second);
    }

    public static List<T> ListOfValues<T>(Func<T> nextItem)
    {
        var list = new List<T>();

        for (int i = 0; i < 5; i++)
        {
            list.Add(nextItem());
        }

        return list;
    }

    public static bool RandomBool()
    {
        return Gen.RandomInt(0, 9) < 5;
    }
}
