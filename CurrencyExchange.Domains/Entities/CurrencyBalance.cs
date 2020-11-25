using System;
using CurrencyExchange.DataAccess.Interfaces;

namespace CurrencyExchange.Domains.Entities
{
    public class CurrencyBalance : IEntity<int>, IEntityWithDate
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ChangeTime { get; set; }
    }
}