using System.Collections.Generic;
using System.Linq;
using week2.Models;
using week2.Service.Interface;
using week2.ViewModels;

namespace week2.Service
{
    public class WeatherforecastService : IWeatherforecastService
    {
        private readonly WeatherforecastContext _weatherforecastContext;

        public WeatherforecastService(WeatherforecastContext weatherforecastContext)
        {
            _weatherforecastContext = weatherforecastContext;
        }

        public WeatherCastRespViewModel Create(WeatherCastViewModel wvm)
        {
            WeatherCast w = new WeatherCast()
            {
                Date = wvm.Date,
                TempC = wvm.TempC,
                TempF = wvm.TempC * 9 / 5 + 32,
                Summary = wvm.Summary,
                IsDeleted = 0
            };
            _weatherforecastContext.Add(w);
            _weatherforecastContext.SaveChanges();
            WeatherCastRespViewModel wrvm = new WeatherCastRespViewModel()
            {
                Id = w.Id,
                Date = w.Date,
                TempC = w.TempC,
                TempF = w.TempF,
                Summary = w.Summary,
            };
            return wrvm;
        }

        public int Delete(int id)
        {
            //var delete = _weatherforecastContext.WeatherCasts.Find(id);
            //if (delete!=null)
            //    _weatherforecastContext.WeatherCasts.Remove(delete);
            //return _weatherforecastContext.SaveChanges();
            var entity = _weatherforecastContext.WeatherCasts.Find(id);
            if (entity != null && entity.IsDeleted == 0)
            {
                entity.IsDeleted = 1;
            }
            return _weatherforecastContext.SaveChanges();
        }

        public List<WeatherCastRespViewModel> ReadAll()
        {
            var entity = _weatherforecastContext.WeatherCasts.Where(w => w.IsDeleted == 0).ToList();
            var result = entity.Select(x => new WeatherCastRespViewModel()
            {
                Id = x.Id,
                Date = x.Date,
                TempC = x.TempC,
                TempF = x.TempF,
                Summary = x.Summary
            }).ToList();
            return result;
        }

        public WeatherCastRespViewModel ReadByID(int id)
        {
            var result = _weatherforecastContext.WeatherCasts.Find(id);
            if (result == null || result.IsDeleted == 1)
                return null;
            WeatherCastRespViewModel wrvm = new WeatherCastRespViewModel()
            {
                Id = result.Id,
                Date = result.Date,
                TempC = result.TempC,
                TempF = result.TempF,
                Summary = result.Summary
            };
            return wrvm;
        }

        public List<WeatherCastRespViewModel> ReadFilter(string filter)
        {
            var entity = _weatherforecastContext.WeatherCasts.Where(w => w.IsDeleted == 0 && w.Summary==filter).ToList();
            var result = entity.Select(x => new WeatherCastRespViewModel()
            {
                Id = x.Id,
                Date = x.Date,
                TempC = x.TempC,
                TempF = x.TempF,
                Summary = x.Summary
            }).ToList();
            return result;
        }

        public int Update(int id, WeatherCastViewModel wvm)
        {
            var entity = _weatherforecastContext.WeatherCasts.Find(id);
            if (entity != null && entity.IsDeleted == 0)
            {
                entity.Date = wvm.Date;
                entity.TempC = wvm.TempC;
                entity.TempF = wvm.TempC * 9 / 5 + 32;
                entity.Summary = wvm.Summary;
            }
            return _weatherforecastContext.SaveChanges();
        }
    }
}