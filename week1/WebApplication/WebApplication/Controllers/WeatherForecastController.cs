using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static List<WeatherForecast> _postdata = new List<WeatherForecast>();

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            /*
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            */
            return _postdata.ToArray();
        }

        [HttpGet("{index}")]
        public IActionResult Get(int index)
        {
            if (index > _postdata.Count()-1)
                return BadRequest();
            else
                return Ok(_postdata[index]);       
        }

        [HttpPost]
        public IActionResult Insert([FromBody] WeatherForecast w)
        {
            _postdata.Add(w);
            return Ok();
        }

        [HttpPost("{index}")]
        public IActionResult Update([FromRoute] int index, [FromBody] WeatherForecast w)
        {
            if (index > _postdata.Count() - 1)
                return BadRequest();
            else
            {
                _postdata[index] = w;
                return Ok();
            }
        }
    }
}
