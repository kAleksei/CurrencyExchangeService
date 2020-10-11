using CurrencyExchange.DataAccess.Interfaces.Repositories;
using CurrencyExchange.Domains.Entities;

namespace CurrencyExchange.DataAccess.Context.Repositories
{
    public class CurrencyArchiveRepository : GenericRepository<CurrencyArchive, int>, ICurrencyArchiveRepository
    {
        public CurrencyArchiveRepository(CurrencyExchangeContext currencyExchangeContext) : base(currencyExchangeContext)
        {
        }
    }
}