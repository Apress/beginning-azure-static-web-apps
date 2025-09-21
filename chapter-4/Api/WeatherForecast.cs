using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Api;

public class WeatherForcast
{
    private readonly ILogger<WeatherForcast> _logger;

    public WeatherForcast(ILogger<WeatherForcast> logger)
    {
        _logger = logger;
    }
    [Function("WeatherForcast")]
    public IActionResult Run(
        [HttpTrigger(
            AuthorizationLevel.Function,
            "get",
            Route = "weather-forecast/{daysToForecast=5}")]
            HttpRequest req,
        int daysToForecast)
    {
        return new
        OkObjectResult(GetWeather(daysToForecast));
    }
    private static dynamic[] GetWeather(int daysToForecast)
    {
        var enumerator = Enumerable.Range(1, daysToForecast);
        var result = new List<dynamic>();
        var rnd = new Random();
        foreach (var day in enumerator)
        {
            var temp = rnd.Next(25);
            var summary = GetSummary(temp);
            result.Add(new
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(day)),
                Summary = summary,
                TemperatureC = temp
            });
        }
        return [.. result];
    }

    private static string GetSummary(int temp)
    {
        return temp switch
        {
            int i when (i > 20) => "Hot!",
            int i when (i > 15) => "Warm",
            int i when (i > 10) => "Cool",
            int i when (i > 5) => "Cold",
            _ => "Too cold!",
        };
    }
}