using System.Text.Json.Serialization;
using WPA.Common.Dto.JsonConverters;

namespace WPA.Common.Dto
{
    [JsonConverter(typeof(WeatherForecastDtoJsonConverter))]
    public class WeatherForecastDto
    {
    }
}
