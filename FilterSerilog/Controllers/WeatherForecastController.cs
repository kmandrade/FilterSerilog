using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FilterSerilog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            try
            {
                _logger.LogInformation($"GET WeatherForecast.");
                _logger.LogWarning("IP:12312312");
                throw new Exception("Erro in Get");

                var result =  Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"error in water");
                return BadRequest($"An error occurred in the request + {ex.Message}");
            }

        }
    }
}