using System;

namespace WeatherCollector.Entities
{
    public class Weather
    {
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
        public double? AirTemperature { get; set; }
        public double? Humidity { get; set; }
        public double? DewPoint { get; set; }
        public int? Pressure { get; set; }
        public string WindDirection { get; set; }
        public int? WindSpeed { get; set; }
        public int? Overcast { get; set; }
        public int? CloudBase { get; set; }
        public int? HorizontalVisibility { get; set; }
        public string WeatherConditions { get; set; }
    }
}
