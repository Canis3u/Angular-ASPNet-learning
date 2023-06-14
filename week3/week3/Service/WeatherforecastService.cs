using System.Collections.Generic;
using System.Linq;
using week3.Models;
using week3.Service.Interface;
using week3.ServiceModels;
using week3.Repositories;
using AutoMapper;
using System;

namespace week3.Service
{
    public class WeatherforecastService : IWeatherforecastService
    {
        private readonly WeatherforecastContext _weatherforecastContext;
        private readonly IMapper _mapper;
        private readonly WeatherforecastRepostory _weatherorecastRepostory;

        public WeatherforecastService(WeatherforecastContext weatherforecastContext, IMapper mapper, WeatherforecastRepostory weatherorecastRepostory)
        {
            _weatherforecastContext = weatherforecastContext;
            _mapper = mapper;
            _weatherorecastRepostory = weatherorecastRepostory;
        }

        public List<WeatherCastRespServiceModel> ReadAll()
        {
            var entity = _weatherforecastContext.WeatherCasts.Where(x => x.IsDeleted == 0).ToList();
            //var entity = _weatherorecastRepostory.ReadAll();
            var wrsm = _mapper.Map<List<WeatherCastRespServiceModel>>(entity);
            return wrsm;
        }

        public WeatherCastRespServiceModel ReadByID(int id)
        {
            var entity = _weatherforecastContext.WeatherCasts.Where(x => x.Id == id && x.IsDeleted==0).FirstOrDefault();
            // var entity = _weatherorecastRepostory.ReadByID(id);
            if (entity == null)
                return null;
            var wrsm = _mapper.Map<WeatherCastRespServiceModel>(entity);
            return wrsm;
        }

        public List<WeatherCastRespServiceModel> ReadFilter(string filter)
        {
            var entity = _weatherforecastContext.WeatherCasts.Where(w => w.IsDeleted == 0 && w.Summary==filter).ToList();
            // var entity = _weatherorecastRepostory.ReadByFilter(filter);
            var wrsm = _mapper.Map<List<WeatherCastRespServiceModel>>(entity);
            return wrsm;
        }
        public WeatherCastRespServiceModel Create(WeatherCastServiceModel wsm)
        {
            var w = _mapper.Map<WeatherCast>(wsm);
            //_weatherforecastContext.Add(w);
            //_weatherforecastContext.SaveChanges();
            var rowschange = _weatherorecastRepostory.Create(w);
            var wrsm = _mapper.Map<WeatherCastRespServiceModel>(w);
            return wrsm;
        }

        public int Update(int id, WeatherCastServiceModel wsm)
        {
            //var entity = _weatherforecastContext.WeatherCasts.Where(x=>x.Id== id && x.IsDeleted == 0).FirstOrDefault();
            //if (entity != null)
            //{
            //    entity.Date = wsm.Date;
            //    entity.TempC = wsm.TempC;
            //    entity.TempF = wsm.TempC * 9 / 5 + 32;
            //    entity.Summary = wsm.Summary;
            //    // _mapper.Map(wsm, entity);
            //}
            //var rowschange = _weatherforecastContext.SaveChanges();
            var w = _mapper.Map<WeatherCast>(wsm);
            var rowschange = _weatherorecastRepostory.Update(id, w);
            return rowschange;
        }

        public int Delete(int id)
        {
            //var entity = _weatherforecastContext.WeatherCasts.Where(x => x.Id == id && x.IsDeleted == 0).FirstOrDefault();
            //if (entity != null)
            //{
            //    entity.IsDeleted = 1;
            //}
            //var rowschange = _weatherforecastContext.SaveChanges();
            var rowschange = _weatherorecastRepostory.Delete(id);
            return rowschange;
        }
    }
}