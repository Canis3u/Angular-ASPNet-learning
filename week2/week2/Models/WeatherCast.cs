using System;
using System.Collections.Generic;

#nullable disable

namespace week2.Models
{
    public partial class WeatherCast
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double TempC { get; set; }
        public double TempF { get; set; }
        public string Summary { get; set; }
        public byte IsDeleted { get; set; }
    }
}
