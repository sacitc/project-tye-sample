using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly BackendContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, BackendContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<string> Get([FromServices] IDistributedCache cache)
        {
            var weather = await cache.GetStringAsync("weather");

            if (weather == null)
            {
                var summaries = _context.Summaries.OrderBy(s => s.Id).Select(s => s.Name).ToArray();
                var rng = new Random();
                var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = summaries[rng.Next(summaries.Length)]
                })
                .ToArray();

                weather = JsonSerializer.Serialize(forecasts);

                await cache.SetStringAsync("weather", weather, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(5)
                });
            }
            return weather;
        }
    }
}
