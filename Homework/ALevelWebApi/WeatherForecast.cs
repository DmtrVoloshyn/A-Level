namespace ALevelWebApi;

public class WeatherForecast
{
    public DateTime CreatedAt { get; set; }
    public double Temperature { get; set; }
    public SummaryType Summary { get; set; }
}

public enum SummaryType
{
    Freezing,
    Bracing,
    Chilly,
    Warm,
    Hot
}