using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyExchange.DataAccess.Interfaces.Repositories;
using CurrencyExchange.Domains.DataTransferObjects.Currency;

namespace CurrencyExchange.BusinessLogic.Interfaces
{
    public interface ICurrencyService
    {
        Task<IEnumerable<CurrencyDTO>> Get(CurrencyFilterDTO filteringModel);
        Task<CurrencyDTO> Create(CurrencyDTO currency);
        Task<CurrencyDTO> Update(CurrencyDTO currency);
        Task Delete(int id);
    }
}