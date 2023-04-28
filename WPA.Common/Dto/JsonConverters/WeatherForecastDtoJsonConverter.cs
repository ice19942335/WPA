using System.Text.Json.Serialization;
using System.Text.Json;

namespace WPA.Common.Dto.JsonConverters
{
    public class WeatherForecastDtoJsonConverter : JsonConverter<WeatherForecastDto>
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(WeatherForecastDto);
        }

        public override WeatherForecastDto Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Implement structure that is required
            /*
            {
                "alias": "riga",
	            "latitude": 56.95,
	            "longitude": 24.11,
	            "hourly_temperature": {
                                {
                                    "00:00": 5,
		            "01:00": 4.5,
		            "02:00": 4,
		            ...
		            "18:00": 15,
		            ...
		            "23:00": 8
                }
            }
            */

                // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/converters-how-to?pivots=dotnet-7-0
                return default;
        }

        public override void Write(Utf8JsonWriter writer, WeatherForecastDto value, JsonSerializerOptions options)
        {
        }
    }
}
