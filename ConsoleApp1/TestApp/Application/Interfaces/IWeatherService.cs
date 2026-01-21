namespace TestApp.Application.Interfaces;

public interface IWeatherService
{
    WeatherForecast[] GetForecast();

    WeatherForecast AddForecast(WeatherForecast forecastInput);

    void DeleteForecast();
}