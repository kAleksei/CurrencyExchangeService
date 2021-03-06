﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyExchange.Domains.DataTransferObjects.City;
using CurrencyExchange.Domains.Entities;

namespace CurrencyExchange.DataAccess.Interfaces.Repositories
{
    public interface ICityRepository: IGenericRepository<City, int>
    {
        Task<IEnumerable<City>> Get(CityFilterDTO filterDTO);
    }
}