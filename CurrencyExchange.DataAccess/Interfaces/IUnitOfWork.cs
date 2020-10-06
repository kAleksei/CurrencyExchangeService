using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CurrencyExchange.DataAccess.Context;

namespace CurrencyExchange.DataAccess.Interfaces
{
    public interface IUnitOfWork: System.IDisposable
    {
        TRepository GetRepository<TRepository>();
        CurrencyExchangeContext GetCurrencyExchangeContext();
        void RegisterRepositoryWithAssembly(Assembly assembly);
        void RegisterRepository<TInterface, TRepository>() where TRepository : TInterface;
        Task Save();
    }

}
