using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherInfo.WeatherReference;
namespace WeatherInfo.Models
{
    public class WeatherViewModel
    {
        private string value { get; set; }
        WeatherService obj = new WeatherService();
        public WeatherViewModel()
        {
              
        }
     
        public void setValue()
        {
            value = obj.GetData(1, true);
        }
        public string getValue()
        {
            return value;
        }
        public Weather getWeather(string city)
        {
            WeatherReference.Weather weather = new WeatherReference.Weather();
            weather =obj.GetWeather(city);
            Weather weatherData = new Weather();
            weatherData.City = weather.City;
            return weatherData;

        }
        public string getWeatherJson(string city)
        {
            return obj.GetWeatherJson(city);

        }
    }
    public class Weather
    {
        bool boolValue = true;
        string cityValue = "";


        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }


        public string City
        {
            get { return cityValue; }
            set { cityValue = value; }
        }
    }

}