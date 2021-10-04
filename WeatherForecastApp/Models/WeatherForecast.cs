using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastApp.Models
{
    public class WeatherForecast
    {
        public string name { get; set; }
        public Coordinates coord { get; set; }
        public List<Weather> weather { get; set; }
        public Main main { get; set; }
        public long visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public Sys sys { get; set; }
    }
}
