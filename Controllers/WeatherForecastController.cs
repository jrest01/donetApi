using Microsoft.AspNetCore.Mvc;

namespace NetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            if (ListWeatherForecast == null || !ListWeatherForecast.Any())
            {
                ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
            .ToList();
            }

        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return ListWeatherForecast;
        }

        [HttpGet]
        [Route("Get/WeatherForecast")]
        [Route("[action]")]
        public IEnumerable<WeatherForecast> Get(int id)
        {
            return ListWeatherForecast;
        }

        [HttpPost]
        public IActionResult Post(WeatherForecast weatherForecast)
        {
            ListWeatherForecast.Add(weatherForecast);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, WeatherForecast weatherForecast)
        {
            var item = ListWeatherForecast[id];
            item.Summary = weatherForecast.Summary;
            item.TemperatureC = weatherForecast.TemperatureC;
            item.Date = weatherForecast.Date;
            return Ok(item);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ListWeatherForecast.RemoveAt(id);
            return Ok();
        }
    }
}
