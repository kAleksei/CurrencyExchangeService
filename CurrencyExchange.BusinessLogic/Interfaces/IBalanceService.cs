using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyExchange.Domains.DataTransferObjects.City;

namespace CurrencyExchange.BusinessLogic.Interfaces
{
    public interface IBalanceService
    {
        Task<bool> WithdrawAllBalances();
        Task<bool> DepositAllBalances();
    }
}