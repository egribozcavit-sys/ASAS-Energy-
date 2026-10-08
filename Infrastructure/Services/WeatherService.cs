using Domain.Interfaces;

namespace Infrastructure.Services;

public sealed class WeatherService : IWeatherService
{
    public Task<WeatherForecast> GetCurrentAsync(
        decimal latitude,
        decimal longitude,
        CancellationToken cancellationToken = default)
    {
        ValidateCoordinates(latitude, longitude);

        var forecast = new WeatherForecast(
            Date: DateTime.UtcNow,
            Temperature: 24.0m,
            Humidity: 52.0m,
            WindSpeed: 3.5m,
            Condition: "Clear",
            SolarIrradiance: 720.0m);

        return Task.FromResult(forecast);
    }

    public Task<WeatherForecast> GetForecastAsync(
        decimal latitude,
        decimal longitude,
        CancellationToken cancellationToken = default)
    {
        ValidateCoordinates(latitude, longitude);

        var forecast = new WeatherForecast(
            Date: DateTime.UtcNow.AddHours(24),
            Temperature: 26.0m,
            Humidity: 48.0m,
            WindSpeed: 4.0m,
            Condition: "Sunny",
            SolarIrradiance: 810.0m);

        return Task.FromResult(forecast);
    }

    private static void ValidateCoordinates(
        decimal latitude,
        decimal longitude)
    {
        if (latitude is < -90 or > 90)
        {
            throw new ArgumentOutOfRangeException(
                nameof(latitude),
                "Latitude must be between -90 and 90.");
        }

        if (longitude is < -180 or > 180)
        {
            throw new ArgumentOutOfRangeException(
                nameof(longitude),
                "Longitude must be between -180 and 180.");
        }
    }
}
