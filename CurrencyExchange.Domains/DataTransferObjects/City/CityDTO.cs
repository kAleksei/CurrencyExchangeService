using System;

namespace CurrencyExchange.Domains.DataTransferObjects.City
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Ratio { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ChangeTime { get; set; }
    }
}