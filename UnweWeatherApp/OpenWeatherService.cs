using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UnweWeatherApp
{
    public class OpenWeatherService
    {
        HttpClient_client;

        public OpenWeatherService()
        {
            _client = new HttpClient();
        }

        public async Task<WeatherData> GetWeatherData(string query)
        {
            WeatherData weatherData = null;

            try
            {
                var response = await_client.GetAsync(query);

                if (response.IsSuccesStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    weatherData = JsonConvert.DeserializeObject<WeatherData>(content);
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }

            return WeatherData;
        }
    }
}
