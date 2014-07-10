using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherInfo.Models;

namespace WeatherInfo.Controllers
{
   
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Weather()
        {            
            WeatherViewModel modelWeatherView = new WeatherViewModel();
            ViewBag.Message = "Showing weather info";
            modelWeatherView.setValue();
            Weather modelWeather = new Models.Weather();
            ViewBag.Weather = modelWeatherView.getWeather("Auburn");
            return View();
        }
    }
}