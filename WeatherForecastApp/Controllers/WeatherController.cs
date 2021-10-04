using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WeatherForecastApp.Services;

namespace WeatherForecastApp.Controllers
{
    public class WeatherController : Controller
    {
        private IWeatherService _weatherService;
        public WeatherController(IWeatherService weatherservice)
        {
            this._weatherService = weatherservice;
        }
        public async Task<IActionResult> Index(string City)
        {
            if(String.IsNullOrEmpty(City))
            {
                return View();
            }
            else
            {
                var model = await _weatherService.GetWeatherForecastForCity(City);
                return View(model);
            }
        }
    }
}
