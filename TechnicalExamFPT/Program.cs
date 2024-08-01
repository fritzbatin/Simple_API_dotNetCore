using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TechnicalExamFPT.Model;

namespace TechnicalExamFPT
{
    class Program
    {
        private static string APIUrl = "http://api.weatherstack.com/";
        private static string AccessKey = "95a9012bc61f18ee1b9b534613004eab";

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            string val;
            bool isNumeric;
            int zipcode;

            Console.Write("Please enter your zip code :");
            val = Console.ReadLine();
            isNumeric = int.TryParse(val, out zipcode);

            if (isNumeric)
            {
                string query = Convert.ToString(zipcode);
                string param = "current?access_key=" + AccessKey + "&query=" + query;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(APIUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync(APIUrl + param);


                    if (response.IsSuccessStatusCode)
                    {
                        WeatherData WeatherResult = await response.Content.ReadAsAsync<WeatherData>();
                        TechnicalExamFPT.Model.IWeatherData rain = new CheckWeather();
                        string isRaining = rain.performWeatherCheck(WeatherResult.current.weather_code);
                       
                        Console.WriteLine("Should I go outside?");
                        Console.WriteLine(isRaining);

                        Console.WriteLine("Should I wear sunscreen?");
                        Console.WriteLine(rain.performUVCheck(WeatherResult.current.uv_index));

                        Console.WriteLine("Can I fly my kite?");
                        Console.WriteLine(rain.performWindSpeedChecAndWeatherk(WeatherResult.current.wind_speed, isRaining));

                        Console.ReadLine();
                    }
                }
            }
            
        }
    }
}
