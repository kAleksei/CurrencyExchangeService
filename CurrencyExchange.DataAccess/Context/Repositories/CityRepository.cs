using CurrencyExchange.DataAccess.Interfaces.Repositories;
using CurrencyExchange.Domains.Entities;

namespace CurrencyExchange.DataAccess.Context.Repositories
{
    public class CityRepository: GenericRepository<City, int>, ICityRepository
    {
        public CityRepository(CurrencyExchangeContext currencyExchangeContext) : base(currencyExchangeContext)
        {
        }

    }
}