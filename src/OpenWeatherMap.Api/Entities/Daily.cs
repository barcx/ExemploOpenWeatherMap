using System.Collections.Generic;

namespace OpenWeatherMap.Api.Entities
{
    public class Daily : Climate
    {
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
        public Temp Temp { get; set; }
        public FeelsLike Feels_like { get; set; }
        public double Pop { get; set; }
        public double Rain { get; set; }
    }
}