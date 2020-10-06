using CurrencyExchange.DataAccess.Interfaces.Repositories;
using CurrencyExchange.Domains.Entities;

namespace CurrencyExchange.DataAccess.Context.Repositories
{
    public class CurrencyRepository : GenericRepository<Currency, int>, ICurrencyRepository
    {
        public CurrencyRepository(CurrencyExchangeContext currencyExchangeContext) : base(currencyExchangeContext)
        {
        }

    }
}