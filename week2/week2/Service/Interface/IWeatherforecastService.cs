using System.Collections.Generic;
using week2.ViewModels;

namespace week2.Service.Interface
{
    public interface IWeatherforecastService
    {
        WeatherCastRespViewModel Create(WeatherCastViewModel wvm);

        int Delete(int id);

        List<WeatherCastRespViewModel> ReadAll();

        WeatherCastRespViewModel ReadByID(int id);

        List<WeatherCastRespViewModel> ReadFilter(string filter);

        int Update(int id, WeatherCastViewModel wvm);
    }
}