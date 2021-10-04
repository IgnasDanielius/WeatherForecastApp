using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherForecastApp.Models;

namespace WeatherForecastApp.Services
{
    public class WeatherService : IWeatherService
    {
        protected readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _clientFactory;

        public WeatherService(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _configuration = configuration;
            _clientFactory = clientFactory;
        }
        public async Task<WeatherForecast> GetWeatherForecastForCity(string City)
        {
            try
            {
                string URI = _configuration.GetSection("WeatherForecastAPIURL").Value + City + _configuration.GetSection("WeatherForecastAPIKey").Value;
                var client = _clientFactory.CreateClient();
                var request = new HttpRequestMessage(HttpMethod.Get,
                URI);
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    var weather = await System.Text.Json.JsonSerializer.DeserializeAsync
                        <WeatherForecast>(responseStream);
                    return weather;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return null;
        }

    }

}
