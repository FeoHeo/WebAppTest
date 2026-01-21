using TestApp.Application.Interfaces;

namespace TestApp.Application.Services;

public class WeatherService : IWeatherService
{
    static string[] _summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public List<WeatherForecast> _forecasts =
        new List<WeatherForecast>(new[]
        {
            new WeatherForecast(
                DateOnly.FromDateTime(DateTime.Now.AddDays(0)),
                Random.Shared.Next(-20, 55),
                _summaries[Random.Shared.Next(_summaries.Length)]
            )
        });


public WeatherForecast[] GetForecast()
    {
        return _forecasts.ToArray();
    }

    public WeatherForecast AddForecast(WeatherForecast forecastInput)
    {
        _forecasts.Add(forecastInput);
        return _forecasts[_forecasts.Count - 1];
    }

    public void DeleteForecast()
    {
        _forecasts.RemoveAt(0);
    }
}