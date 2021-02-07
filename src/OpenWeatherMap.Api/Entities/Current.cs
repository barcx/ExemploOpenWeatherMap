namespace OpenWeatherMap.Api.Entities
{
    public class Current : Climate
    {
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
        public double Temp { get; set; }
        public double Feels_like { get; set; }
        public int Visibility { get; set; }
    }
}
