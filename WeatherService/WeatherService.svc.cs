using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WeatherService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class WeatherService : IWeather
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public Weather GetWeather(string city)
        {
            Weather weather = new Weather();
            if (weather == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (weather.BoolValue)
            {
                weather.City += "Suffix";
            }
            return weather;
        }

        public string GetWeatherJson(string city)
        {
            Weather weather = new Weather();
            if (weather == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (weather.BoolValue)
            {
                weather.City += "Suffix";
            }
            return weather.City;
        }
    }
}
