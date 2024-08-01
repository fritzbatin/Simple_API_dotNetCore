using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalExamFPT.Model
{
    public interface IWeatherData
    {
        string performWeatherCheck(int weatherCode);
        string performUVCheck(int UVindex);
        string performWindSpeedChecAndWeatherk(int windSpeed, string IsNotRaining);
    }
}
