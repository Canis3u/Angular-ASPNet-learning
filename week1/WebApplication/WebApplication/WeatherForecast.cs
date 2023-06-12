using System;

namespace WebApplication
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}

/*Scaffold-DbContext "Server=LAPTOP-D0C7EI0R;Database=Weatherforecast;Trusted_Connection=True;TrustServerCertificate=True;User ID=sa;Password=qqqqqqqqqqqqqqq" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force*/