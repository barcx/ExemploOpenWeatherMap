using System.Collections.Generic;

namespace OpenWeatherMap.Api.Entities
{
    public class OpenWeather
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Timezone { get; set; }
        public int Timezone_offset { get; set; }
        public Current Current { get; set; }
        public List<Minutely> Minutely { get; set; }
        public List<Hourly> Hourly { get; set; }
        public List<Daily> Daily { get; set; }
    }
}