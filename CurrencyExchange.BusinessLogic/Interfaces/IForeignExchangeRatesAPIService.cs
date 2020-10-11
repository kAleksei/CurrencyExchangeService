using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyExchange.Domains.DataTransferObjects.Currency;

namespace CurrencyExchange.BusinessLogic.Interfaces
{
    public interface IForeignExchangeRatesAPIService
    {
        Task<IEnumerable<CurrencyDTO>> GetRatesFromAPI();
        Task<bool> UpdateAllCurrenciesByCities();
    }
}