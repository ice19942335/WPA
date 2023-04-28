using WPA.Common.Configuration;

namespace WPA.Application.Validators
{
    public class WeatherForecastValidator : IWeatherForecastValidator
    {
        private readonly WeatherForecastSettings _weatherForecastSettings;

        public WeatherForecastValidator(AppSettings appSettings)
        {
            _weatherForecastSettings = appSettings.WeatherForecastLocations;
        }

        public bool IsValid(string location)
        {
            return _weatherForecastSettings.AllowedLocations.Any(x => x.Alias.ToLower() == location.ToLower());
        }
    }

    public interface IWeatherForecastValidator
    {
        bool IsValid(string location);
    }
}
