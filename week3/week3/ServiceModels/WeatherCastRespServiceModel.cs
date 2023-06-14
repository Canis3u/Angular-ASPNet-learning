using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace week3.ServiceModels
{
    public class WeatherCastRespServiceModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double TempC { get; set; }
        public double TempF { get; set; }
        public string Summary { get; set; }
    }
}
