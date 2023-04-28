using System.Text.Json;
using WPA.Common.Configuration;
using WPA.Common.Dto;
using WPA.Infrastructure;

public class WeatherService : IWeatherService
{
    private readonly IWeatherRepository _weatherRepository;
    private readonly AppSettings _appSettings;

    public WeatherService(IWeatherRepository weatherRepository, AppSettings appSettings)
    {
        _weatherRepository = weatherRepository;
        _appSettings = appSettings;
    }

    public async Task<WeatherForecastDto> GetWeatherForecast(string location)
    {
        var locationSettings = _appSettings.WeatherForecastLocations.AllowedLocations.FirstOrDefault(x => x.Alias.ToLower() == location.ToLower());
        if (locationSettings is null)
        {
            throw new ApplicationException($"{location} does not exist in allowed location list");
        }
        var weatherAsJson = await _weatherRepository.GetForecast(locationSettings.Latitude, locationSettings.Longitude);

        return JsonSerializer.Deserialize<WeatherForecastDto>(weatherAsJson);
    }
}

public interface IWeatherService
{
    Task<WeatherForecastDto> GetWeatherForecast(string location);
}