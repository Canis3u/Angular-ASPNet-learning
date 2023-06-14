using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using week3.Service.Interface;
using week3.ServiceModels;
using week3.ViewModels;

namespace week3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherforecastService _weatherforecastService;
        private readonly IMapper _mapper;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherforecastService weatherforecastService, IMapper mapper)
        {
            _logger = logger;
            _weatherforecastService = weatherforecastService;
            _mapper = mapper;
        }

        // 取出全部資料
        [HttpGet]
        public ActionResult<IEnumerable<WeatherCastRespViewModel>> Get()
        {
            this.WriteLog(nameof(Get), Request.Headers,null);
            var wrsm = _weatherforecastService.ReadAll();
            var wrvm = _mapper.Map<List<WeatherCastRespViewModel>>(wrsm);
            return wrvm;
        }

        // 取出單筆資料
        [HttpGet("{id}")]
        public ActionResult<WeatherCastRespViewModel> Get(int id)
        {
            this.WriteLog(nameof(Get), Request.Headers, JsonSerializer.Serialize<int>(id));
            var wrsm = _weatherforecastService.ReadByID(id);
            var wrvm = _mapper.Map<WeatherCastRespViewModel>(wrsm);
            if (wrvm == null)
                return BadRequest("id not foumd");
            else
                return wrvm;
        }

        [HttpGet("filter/{filter}")]
        public ActionResult<IEnumerable<WeatherCastRespViewModel>> Get(string filter)
        {
            this.WriteLog(nameof(Get), Request.Headers, JsonSerializer.Serialize<string>(filter));
            var wrsm = _weatherforecastService.ReadFilter(filter);
            var wrvm = _mapper.Map<List<WeatherCastRespViewModel>>(wrsm);
            return wrvm;
        }

        // 新增單筆資料
        [HttpPost]
        public ActionResult<WeatherCastRespViewModel> Post([FromBody] WeatherCastViewModel wvm)
        {
            this.WriteLog(nameof(Post), Request.Headers, JsonSerializer.Serialize<WeatherCastViewModel>(wvm));
            var wsm = _mapper.Map<WeatherCastServiceModel>(wvm);
            var wrsm = _weatherforecastService.Create(wsm);
            var wrvm = _mapper.Map<WeatherCastRespViewModel>(wrsm);
            return CreatedAtAction(nameof(Get), new { id = wrvm.Id }, wrvm);
        }

        // 更新單筆資料
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] WeatherCastViewModel wvm)
        {
            this.WriteLog(nameof(Put), Request.Headers, $"{JsonSerializer.Serialize<int>(id)},{ JsonSerializer.Serialize<WeatherCastViewModel>(wvm)}");
            var wsm = _mapper.Map<WeatherCastServiceModel>(wvm);
            var result = _weatherforecastService.Update(id, wsm);
            if (result == 0)
                return BadRequest("id not foumd");
            return NoContent();
        }

        // 刪除單筆資料
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.WriteLog(nameof(Delete), Request.Headers, JsonSerializer.Serialize<int>(id));
            var result = _weatherforecastService.Delete(id);
            if (result == 0)
                return BadRequest("id not found");
            return NoContent();
        }
        private void WriteLog(string name, IHeaderDictionary headers, string body)
        {
            var token = "token";
            if (headers.TryGetValue("my-token", out var values))
                token = values.ToList().FirstOrDefault();
            Console.WriteLine($"{name},{token},{body}");
        }
    }
}