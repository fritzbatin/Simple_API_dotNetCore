using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalExamFPT.Model
{
    
    public class CheckWeather : IWeatherData
    {
        //Polymorphism
        public string performWeatherCheck(int weatherCode)
        {
            List<int> rainingcodes = new List<int>();
            rainingcodes.Add(176);
            rainingcodes.Add(293);
            rainingcodes.Add(296);
            rainingcodes.Add(299);
            rainingcodes.Add(302);
            rainingcodes.Add(305);
            rainingcodes.Add(308);
            rainingcodes.Add(311);
            if (rainingcodes.Contains(weatherCode))
            {
                return "No";
            }
            else
            {
                return "Yes";
            }
        }

        public string performUVCheck(int UVindex)
        {
            if (UVindex > 3)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }

        public string performWindSpeedChecAndWeatherk(int windSpeed, string IsNotRaining)
        {
            if (windSpeed > 15 || IsNotRaining == "No")
            {
                return "No";
            }
            else
            {
                return "Yes";
            }

        }
    }

}
