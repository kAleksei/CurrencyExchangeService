using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.DataAccess.Interfaces.Repositories;
using CurrencyExchange.Domains.DataTransferObjects.City;
using CurrencyExchange.Domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.DataAccess.Context.Repositories
{
    public class BalanceRepository : GenericRepository<CurrencyBalance, int>, IBalanceRepository
    {
        public BalanceRepository(CurrencyExchangeContext currencyExchangeContext) : base(currencyExchangeContext)
        {
        }

       
    }
}