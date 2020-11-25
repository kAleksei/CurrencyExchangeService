using System;
using CurrencyExchange.Domains.Enums.Currency;

namespace CurrencyExchange.Domains.DataTransferObjects.Currency
{
    public class CurrencyDTO: ICloneable
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string CurrencyName { get; set; }
        public DateTime LastUpdate { get; set; }
        public double Rate { get; set; }
        public int CityId { get; set; }
        public CurrencyTrending CurrencyTrending { get; set; }
        public double Balance { get; set; }
        public DateTime LastBalanceUpdate { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}