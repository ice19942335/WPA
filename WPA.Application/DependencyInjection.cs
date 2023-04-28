using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using WPA.Common.Configuration;
using WPA.Application.Validators;
using WPA.Infrastructure;

namespace CleanArchitecture.Application
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IWeatherService, WeatherService>();
        }

        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<IWeatherForecastValidator, WeatherForecastValidator>();
            services.AddTransient<IWeatherRepository, WeatherRepository>();
        }

        public static void AddSettings(this IServiceCollection services)
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            var json = File.ReadAllText("appsettings.json");
            AppSettings appSettings = JsonSerializer.Deserialize<AppSettings>(json, options);

            services.AddSingleton(appSettings);
        }
    }
}
