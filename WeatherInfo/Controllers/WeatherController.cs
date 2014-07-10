using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using WeatherInfo.WeatherReference;
using WeatherInfo.Models;

namespace WeatherInfo.Controllers
{
    public class WeatherController : ApiController
    {
      
        //
        // GET: /Weather/
        
        public string GetWeather()
        {
            WeatherViewModel modelWeatherView = new WeatherViewModel();
           string data = modelWeatherView.getWeatherJson("Auburn");
            //return Json(data,JsonRequestBe);

           return "";

        }
	}
}