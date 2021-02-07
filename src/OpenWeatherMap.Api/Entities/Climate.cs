using System.Collections.Generic;

namespace OpenWeatherMap.Api.Entities
{
    public class Climate
    {
        public int Dt { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double Dew_point { get; set; }
        public double Uvi { get; set; }
        public int Clouds { get; set; }
        public double Wind_speed { get; set; }
        public int Wind_deg { get; set; }
        public List<Weather> Weather { get; set; }
    }
}