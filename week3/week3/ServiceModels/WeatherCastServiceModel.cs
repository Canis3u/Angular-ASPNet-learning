using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace week3.ServiceModels
{
    public class WeatherCastServiceModel
    {
        public DateTime Date { get; set; }
        public double TempC { get; set; }
        public string Summary { get; set; }
    }
}
