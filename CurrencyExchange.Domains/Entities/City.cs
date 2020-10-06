using System;
using CurrencyExchange.DataAccess.Interfaces;

namespace CurrencyExchange.Domains.Entities
{
    public class City: IEntity<int>, IEntityWithDate
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ChangeTime { get; set; }
    }
}