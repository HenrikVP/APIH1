using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIH1
{
    internal class WeatherAPI
    {
        public void GetWeather()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($@"https://api.openweathermap.org/data/2.5/weather?lat=55.7323014&lon=12.3435126&units=metric&appid=7e53483f93ea0edcd217d7d8dd88c3b3
"),
                //55.7323014,12.3435126
    //            Headers =
    //{
    //    //{ "X-RapidAPI-Key", "SIGN-UP-FOR-KEY" },
    //    //{ "X-RapidAPI-Host", "imdb8.p.rapidapi.com" },
    //},
            };
            using (var response = client.Send(request))
            {
                response.EnsureSuccessStatusCode();

                var body = response.Content.ReadAsStream();
                using var reader = new StreamReader(response.Content.ReadAsStream());
                string json = reader.ReadToEnd();
                Console.WriteLine(json);
                Root root = JsonSerializer.Deserialize<Root>(json);

                Console.WriteLine(root.wind.deg);

                Console.WriteLine();
            }
        }
    }
}
