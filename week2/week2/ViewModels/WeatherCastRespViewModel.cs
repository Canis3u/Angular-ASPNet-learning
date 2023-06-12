using System;

namespace week2.ViewModels
{
    public class WeatherCastRespViewModel
    {
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public string Summary { get; set; }
        public double TempC { get; set; }
        public double TempF { get; set; }
    }
}