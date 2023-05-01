using Microsoft.AspNetCore.Authentication;

namespace ApiRestService.Models
{
    public class Weather
    {

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

      //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public double TemperatureF => 32 + (double)TemperatureC * 9 / 5;

        public string? Summary { get; set; }
    }
}