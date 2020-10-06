using System;
using CurrencyExchange.DataAccess.Interfaces;

namespace CurrencyExchange.Domains.Entities
{
    public class Currency: IEntity<int>, IEntityWithDate
    {
        public int Id { get; set; }

        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencySymbol { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime ChangeTime { get; set; }
    }
}