using System;

namespace week3.ViewModels
{
    public class WeatherCastRespViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double TempC { get; set; }
        public double TempF { get; set; }
        public string Summary { get; set; }
    }
}