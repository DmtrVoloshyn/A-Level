namespace ALevelWebApi;

public class WeatherForecastService
{
    public SummaryType GetSummary(int temperature) => temperature switch
    {
        0 => SummaryType.Bracing,
        < 20 => SummaryType.Freezing,
        > 15 => SummaryType.Warm,
    };
}