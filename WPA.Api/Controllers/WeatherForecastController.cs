using Microsoft.AspNetCore.Mvc;
using WPA.Application.Validators;
using WPA.Common.Dto;

namespace WPA.Api.Controllers
{
    [ApiController]
    [Route("weather-api")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("locations/{location}/temperature")]
        public async Task<ActionResult<WeatherForecastDto>> Get([FromRoute]string location, [FromServices] IWeatherForecastValidator validator)
        {
            if (!validator.IsValid(location))
            {
                return BadRequest(new { ErrorMessage = $"{location} is not allowed" });
            }
            else
            {
                return await _weatherService.GetWeatherForecast(location);
            }
        }
    }
}