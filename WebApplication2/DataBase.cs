using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2
{
    public interface DBInterface
    {
        public WeatherForecast Get(int id);
        public WeatherForecast Delete(int id);
        public IEnumerable<WeatherForecast> GetAll();
        public WeatherForecast Add(WeatherForecast item);
        public WeatherForecast Update(int id, WeatherForecast item);
        public IEnumerable<WeatherForecast> GetFiltered(DateTime time1, DateTime time2);
    }

    public class DataBase : DBInterface
    {
        List<WeatherForecast> database;
        public DataBase()
        {
            WeatherForecast item = new WeatherForecast();
            database = new List<WeatherForecast>();
            database.Add(new WeatherForecast { ID = 1, Date = new DateTime(2022, 06, 21), TemperatureC = 14, Summary = "небольшой дождь", Icon = "10d" });
            database.Add(new WeatherForecast { ID = 2, Date = new DateTime(2022, 06, 22), TemperatureC = 16, Summary = "переменная облачность", Icon = "03d" });
            database.Add(new WeatherForecast { ID = 3, Date = new DateTime(2022, 06, 23), TemperatureC = 16, Summary = "пасмурно", Icon = "04d" });
        }
        WeatherForecast DBInterface.Get(int id)
        {
            foreach (WeatherForecast item in database)
            {
                if (item.ID == id)
                    return item;
            }
            return null;
        }
        WeatherForecast DBInterface.Delete(int id)
        {
            foreach (WeatherForecast item in database)
            {
                if (item.ID == id)
                {
                    database.Remove(item);
                    return item;
                }
            }
            return null;
        }
        IEnumerable<WeatherForecast> DBInterface.GetAll()
        {
            return database;
        }
        WeatherForecast DBInterface.Add(WeatherForecast item)
        {
            database.Add(item);
            return item;
        }
        WeatherForecast DBInterface.Update(int id, WeatherForecast item)
        {
            for(int i = 0; i <= database.Count; i++)
            {
                if(database[i].ID == id)
                {
                    database[i] = item;
                    return database[i];
                }
            }
            return null;
        }
        IEnumerable<WeatherForecast> DBInterface.GetFiltered(DateTime time1, DateTime time2)
        {
            List<WeatherForecast> weatherForecasts = new List<WeatherForecast>();
            foreach(WeatherForecast item in database)
            {
                if(item.Date >= time1 && item.Date <= time2)
                {
                    weatherForecasts.Add(item);
                }
            }
            return weatherForecasts;
        }
    }
}