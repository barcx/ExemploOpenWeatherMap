namespace OpenWeatherMap.Api.Entities
{
    public class Hourly : Climate
    {
        public double Temp { get; set; }
        public int Visibility { get; set; }
        public double Pop { get; set; }
        //public Rain Rain { get; set; }
    }
}