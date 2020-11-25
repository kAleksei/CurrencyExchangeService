using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyExchange.Domains.DataTransferObjects.City;
using CurrencyExchange.Domains.Entities;

namespace CurrencyExchange.DataAccess.Interfaces.Repositories
{
    public interface IBalanceRepository: IGenericRepository<CurrencyBalance, int>
    {
    }
}