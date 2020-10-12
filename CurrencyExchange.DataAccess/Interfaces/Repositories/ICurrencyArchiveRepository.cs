using System.Threading.Tasks;
using CurrencyExchange.Domains.Entities;

namespace CurrencyExchange.DataAccess.Interfaces.Repositories
{
    public interface ICurrencyArchiveRepository : IGenericRepository<CurrencyArchive, int>
    {
        Task<CurrencyArchive> GetPreviousCurrencyChange(int currencyId, int cityId);
    }
}