using Domain.Interfaces;
using Infrastructure.IoT;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddHttpClient();

        services.AddScoped<IEnergyService, EnergyService>();
        services.AddScoped<IIoTService, IoTService>();
        services.AddScoped<IWeatherService, WeatherService>();

        return services;
    }
}
