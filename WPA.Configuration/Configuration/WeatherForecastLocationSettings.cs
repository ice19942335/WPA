namespace WPA.Application.Configuration
{
    public class WeatherForecastSettings
    {
        public List<WeatherForecastLocationSettings> AllowedLocations { get; set; }
    }

    public class WeatherForecastLocationSettings
    {
        public string Alias { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
