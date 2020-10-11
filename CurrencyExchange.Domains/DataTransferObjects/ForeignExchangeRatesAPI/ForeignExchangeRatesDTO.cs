using System;
using System.Collections.Generic;

namespace CurrencyExchange.Domains.DataTransferObjects.ForeignExchangeRatesAPI
{
    public class ForeignExchangeRatesDTO
    {
        public Dictionary<string, double> Rates { get; set; }
        public string Base { get; set; }
        public DateTime Date { get; set; }

        public ForeignExchangeRatesDTO()
        {
            Rates = new Dictionary<string, double>();
        }
    }
}