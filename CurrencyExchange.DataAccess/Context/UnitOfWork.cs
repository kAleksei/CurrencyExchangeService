using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CurrencyExchange.DataAccess.Context.Repositories;
using CurrencyExchange.DataAccess.Interfaces;

namespace CurrencyExchange.DataAccess.Context
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CurrencyExchangeContext _currencyExchangeContext;
        private IDictionary<Type, object> _repositories;

        public UnitOfWork(CurrencyExchangeContext currencyExchangeContext)
        {
            _currencyExchangeContext = currencyExchangeContext;
            _repositories = new ConcurrentDictionary<Type, object>();
        }

        public TRepository GetRepository<TRepository>()
        {
            Type key = typeof(TRepository);
            if (!_repositories.ContainsKey(key))
            {
                throw new KeyNotFoundException("Current repository does not exist");
            }

            return (TRepository)_repositories[key];
        }

        public CurrencyExchangeContext GetCurrencyExchangeContext()
        {
            return _currencyExchangeContext;
        }

        public void RegisterRepositoryWithAssembly(Assembly assembly)
        {
            IDictionary<Type, object> repositories = ScanAssembly(assembly);

            _repositories = new ConcurrentDictionary<Type, object>(repositories);
        }

        public void RegisterRepository<TInterface, TRepository>() where TRepository : TInterface
        {
            _repositories[typeof(TInterface)] = Activator.CreateInstance(typeof(TRepository), new object[] { this._currencyExchangeContext });
        }

        public virtual async Task Save()
        {
            await _currencyExchangeContext.SaveChangesAsync();
        }


        #region Private functions
        private IDictionary<Type, object> ScanAssembly(Assembly assembly)
        {
            IEnumerable<Type> interfaces = LoadRepositoriesInterfaces();
            IEnumerable<Type> implementation = LoadRepositoriesImplementation(assembly);
            IDictionary<Type, object> repositories = JoinAbstractionAndImplementation(interfaces, implementation);

            return repositories;
        }

        private IEnumerable<Type> LoadRepositoriesInterfaces()
        {
            return
                from t in Assembly.GetExecutingAssembly().GetTypes()
                from ti in t.GetInterfaces()
                where t.IsInterface && ti.IsGenericType && ti.GetGenericTypeDefinition() == typeof(IGenericRepository<,>)
                select t;
        }

        private IEnumerable<Type> LoadRepositoriesImplementation(Assembly assembly)
        {
            return
                from t in assembly.GetTypes()
                from ti in t.GetInterfaces()
                where t.IsClass && !t.IsAbstract && ti.IsGenericType && ti.GetGenericTypeDefinition() == typeof(IGenericRepository<,>)
                select t;
        }

        private IDictionary<Type, object> JoinAbstractionAndImplementation(IEnumerable<Type> abstractions, IEnumerable<Type> implementation)
        {
            return
                (from impl in implementation
                    from i in impl.GetInterfaces()
                    join abst in abstractions on i equals abst
                    where abst.IsAssignableFrom(impl)
                    select new { abst = abst, impl })
                .ToDictionary(k => k.abst, v => Activator.CreateInstance(v.impl, new object[] { this._currencyExchangeContext }));
        }

        #endregion


        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _repositories.Clear();
                    _currencyExchangeContext.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
