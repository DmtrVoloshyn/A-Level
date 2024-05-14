using Microsoft.AspNetCore.Mvc;

namespace ALevelWebApi;

[ApiController]
[Route("WeatherForecast")]
public class WeatherForecastController
{
    [HttpGet("GetForecast")]
    public IEnumerable<WeatherForecast> Get()
    { 
        var weatherService = new WeatherForecastService();
        int temperature = Random.Shared.Next(-50, 45);


        return Enumerable
            .Range(1, 5)
            .Select(_ =>
                new WeatherForecast
                {
                    CreatedAt = DateTime.Now,
                    Temperature = temperature,
                    Summary = weatherService.GetSummary(temperature)
                });
    }
    
    [HttpPost("CalculateSummary")]
    public string Post(CalculateForecast input)
    {
        if (input is null)
        {
            return "input empty";
        }
        var weatherService = new WeatherForecastService();

        return weatherService.GetSummary((input.Temperature)).ToString();


    }
    
    
}