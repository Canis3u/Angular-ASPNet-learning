using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication.Models
{
    public partial class Weathercase
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double TempC { get; set; }
        public double TempF { get; set; }
        public string Summary { get; set; }
    }
}
