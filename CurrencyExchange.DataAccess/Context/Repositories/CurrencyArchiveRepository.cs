using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.DataAccess.Interfaces.Repositories;
using CurrencyExchange.Domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.DataAccess.Context.Repositories
{
    public class CurrencyArchiveRepository : GenericRepository<CurrencyArchive, int>, ICurrencyArchiveRepository
    {
        public CurrencyArchiveRepository(CurrencyExchangeContext currencyExchangeContext) : base(currencyExchangeContext)
        {
        }

        public async Task<CurrencyArchive> GetPreviousCurrencyChange(int currencyId, int cityId)
        {
            return await _currencyExchangeContext.Set<CurrencyArchive>().Where(c => c.CurrencyId == currencyId && c.CityId == cityId).Include(c => c.CurrencyReference).OrderByDescending(c => c.ChangeTime).FirstOrDefaultAsync();
        }
    }
}