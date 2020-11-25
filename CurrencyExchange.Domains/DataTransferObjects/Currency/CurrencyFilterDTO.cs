using System;
using CurrencyExchange.Domains.Entities;
using CurrencyExchange.Domains.Interfaces;

namespace CurrencyExchange.Domains.DataTransferObjects.Currency
{
    public class CurrencyFilterDTO: ICountSkipModel
    {
        public string SearchTerm { get; set; }
        public int? CityId { get; set; }
        public DateTime? CurrencyDate { get; set; }
        public int Count { get; set; }
        public int Skip { get; set; }
        public bool WithHistory { get; set; }
        public bool WithBalance { get; set; }
    }
}
