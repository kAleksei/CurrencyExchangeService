using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyExchange.Domains.DataTransferObjects.Currency;
using CurrencyExchange.Domains.Entities;

namespace CurrencyExchange.DataAccess.Interfaces.Repositories
{
    public interface ICurrencyRepository: IGenericRepository<Currency, int>
    {
        Task<IEnumerable<Currency>> Get(CurrencyFilterDTO filteringModel);
        
    }
}