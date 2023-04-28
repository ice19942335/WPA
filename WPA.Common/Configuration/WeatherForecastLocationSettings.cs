namespace WPA.Common.Configuration
{
    public class WeatherForecastSettings
    {
        public List<WeatherForecastLocationSettings> AllowedLocations { get; set; }
    }

    public class WeatherForecastLocationSettings
    {
        public string Alias { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
