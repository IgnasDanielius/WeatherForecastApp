using System.Threading.Tasks;
using WeatherForecastApp.Models;

namespace WeatherForecastApp.Services
{
    public interface IWeatherService
    {
        Task<WeatherForecast> GetWeatherForecastForCity(string City);
    }
}
