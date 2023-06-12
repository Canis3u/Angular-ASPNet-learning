using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json;
using week2.Service.Interface;
using week2.ViewModels;

namespace week2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherforecastService _weatherforecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherforecastService weatherforecastService)
        {
            _logger = logger;
            _weatherforecastService = weatherforecastService;
        }

        // 取出全部資料
        [HttpGet]
        public ActionResult<IEnumerable<WeatherCastRespViewModel>> Get()
        {
            Console.WriteLine($"{nameof(Get)}");
            var result = _weatherforecastService.ReadAll();
            return result;
        }

        // 取出單筆資料
        [HttpGet("{id}")]
        public ActionResult<WeatherCastRespViewModel> Get(int id)
        {
            Console.WriteLine($"{nameof(Get)},{JsonSerializer.Serialize<int>(id)}");
            var result = _weatherforecastService.ReadByID(id);
            if (result == null)
                return BadRequest("id not foumd");
            else
                return result;
        }

        [HttpGet("filter/{filter}")]
        public ActionResult<IEnumerable<WeatherCastRespViewModel>> Get(string filter)
        {
            Console.WriteLine($"{nameof(Get)},{JsonSerializer.Serialize<string>(filter)}");
            var result = _weatherforecastService.ReadFilter(filter);
            return result;
        }

        // 新增單筆資料
        [HttpPost]
        public ActionResult<WeatherCastRespViewModel> Post([FromBody] WeatherCastViewModel wvm)
        {
            Console.WriteLine($"{nameof(Post)},{JsonSerializer.Serialize<WeatherCastViewModel>(wvm)}");
            var result = _weatherforecastService.Create(wvm);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        // 更新單筆資料
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] WeatherCastViewModel wvm)
        {
            Console.WriteLine($"{nameof(Put)},{JsonSerializer.Serialize<int>(id)},{JsonSerializer.Serialize<WeatherCastViewModel>(wvm)}");
            var result = _weatherforecastService.Update(id, wvm);
            if (result == 0)
                return BadRequest("id not foumd");
            return NoContent();
        }

        // 刪除單筆資料
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Console.WriteLine($"{nameof(Delete)},{JsonSerializer.Serialize<int>(id)}");
            var result = _weatherforecastService.Delete(id);
            if (result == 0)
                return BadRequest("id not found");
            return NoContent();
        }
    }
}