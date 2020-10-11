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
    public class CityRepository: GenericRepository<City, int>, ICityRepository
    {
        public CityRepository(CurrencyExchangeContext currencyExchangeContext) : base(currencyExchangeContext)
        {
        }

        public async Task<IEnumerable<City>> Get(CityFilterDTO filterDTO)
        {
            var query = CreateQuery(filterDTO);
            return await query.ToListAsync();
        }

        private IQueryable<City> CreateQuery(CityFilterDTO filterDTO)
        {
            var query = _currencyExchangeContext.Set<City>().AsQueryable();
            if (filterDTO == null) return query;

            if (string.IsNullOrWhiteSpace(filterDTO.Name) == false)
            {
                query = query.Where(c => c.CityName.Contains(filterDTO.Name));
            }

            return query;
        }
    }
}