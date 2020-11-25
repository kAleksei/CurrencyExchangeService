using CurrencyExchange.DataAccess.Interfaces.Repositories;
using CurrencyExchange.Domains.DataTransferObjects.Currency;
using CurrencyExchange.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.DataAccess.Context.Repositories
{
    public class CurrencyRepository : GenericRepository<Currency, int>, ICurrencyRepository
    {
        public CurrencyRepository(CurrencyExchangeContext currencyExchangeContext) : base(currencyExchangeContext)
        {
        }

        public override async Task<Currency> Insert(Currency entity)
        {
            entity.CurrencyCode = entity.CurrencyCode.ToLower();
            entity.CreateTime = DateTime.Now;
            entity.ChangeTime = entity.CreateTime;
            return await base.Insert(entity);
        }

        public override async Task<Currency> Update(Currency entityToUpdate)
        {
            entityToUpdate.CurrencyCode = entityToUpdate.CurrencyCode.ToLower();
            await base.Update(entityToUpdate);
            return entityToUpdate;
        }

        public async Task<IEnumerable<Currency>> Get(CurrencyFilterDTO filteringModel)
        {
            var query = FilterCurrencies(filteringModel);
            
            query = query.Include(c => c.City);
            if (filteringModel.WithBalance)
            {
                query = query.Include(c => c.CurrencyBalance);
            }
            return await query.ToListAsync();
        }

        #region Private functions

        private IQueryable<Currency> FilterCurrencies(CurrencyFilterDTO filteringModel)
        {
            var query = _currencyExchangeContext.Set<Currency>().AsQueryable();

            if (filteringModel == null) return query;

            if (!string.IsNullOrWhiteSpace(filteringModel.SearchTerm))
            {
                var trimmedSearchTerm = filteringModel.SearchTerm.Trim();
               query = query.Where(c =>
                    c.CurrencyCode.Contains(trimmedSearchTerm, StringComparison.InvariantCultureIgnoreCase) ||
                    c.CurrencyName.Contains(trimmedSearchTerm, StringComparison.InvariantCultureIgnoreCase));
            }
            if (filteringModel.CityId.HasValue && filteringModel.CityId.Value > 0)
            {
                query = query.Where(c => c.CityId == filteringModel.CityId.Value);
            }
            if (filteringModel.CurrencyDate.HasValue && filteringModel.CurrencyDate.Value > DateTime.MinValue)
            {
                query = query.Where(c => c.ChangeTime == filteringModel.CurrencyDate);
            }
            return query;
        }
        #endregion
    }
}