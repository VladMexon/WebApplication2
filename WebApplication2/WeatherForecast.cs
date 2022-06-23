using System;

namespace WebApplication2
{
    [Serializable]
    public class WeatherForecast
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Icon { get; set; }

        public string Summary { get; set; }
    }
}
