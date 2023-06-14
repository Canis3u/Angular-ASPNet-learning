using System.Collections.Generic;
using week3.ServiceModels;

namespace week3.Service.Interface
{
    public interface IWeatherforecastService
    {
        WeatherCastRespServiceModel Create(WeatherCastServiceModel wsm);

        int Delete(int id);

        List<WeatherCastRespServiceModel> ReadAll();

        WeatherCastRespServiceModel ReadByID(int id);

        List<WeatherCastRespServiceModel> ReadFilter(string filter);

        int Update(int id, WeatherCastServiceModel wsm);
    }
}