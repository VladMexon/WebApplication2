using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DBInterface _database;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DBInterface dBInterface)
        {
            _logger = logger;
            _database = dBInterface;
        }

        [HttpGet("{id}")]
        public WeatherForecast Get(int id)
        {
            return _database.Get(id);
        }
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _database.GetAll();
        }
        [HttpPost]
        public WeatherForecast Post(WeatherForecast item)
        {
            return _database.Add(item);
        }
        [HttpPut("{id}")]
        public WeatherForecast Update(int id, WeatherForecast item)
        {
            return _database.Update(id, item);
        }
        [HttpDelete("{id}")]
        public WeatherForecast Delete(int id)
        {
            return _database.Delete(id);
        }
        [HttpGet("getByDate")]
        public IEnumerable<WeatherForecast> GetFiltered(String time1, String time2)
        {

            return _database.GetFiltered(DateTime.Parse(time1), DateTime.Parse(time2));
        }
    }
}
