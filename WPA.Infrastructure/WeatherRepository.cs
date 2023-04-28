using WPA.Common.Configuration;

namespace WPA.Infrastructure
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AppSettings _appSettings;

        public WeatherRepository(IHttpClientFactory httpClientFactory, AppSettings appSettings)
        {
            _httpClientFactory = httpClientFactory;
            _appSettings = appSettings;
        }

        public async Task<string> GetForecast(string latitude, string longitude)
        {
            var url = $"{_appSettings.WeatherBaseUrl}forecast?latitude={latitude}&longitude={longitude}&hourly=temperature_2m";
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return await httpResponseMessage.Content.ReadAsStringAsync();
            }
            else
            {
                throw new HttpRequestException("Something went wrong");
            }
        }
    }

    public interface IWeatherRepository
    {
        Task<string> GetForecast(string latitude, string longitude);
    }
}