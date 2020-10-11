using System.Collections.Generic;
using System.Threading.Tasks;
using CurrencyExchange.Domains.DataTransferObjects.City;

namespace CurrencyExchange.BusinessLogic.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityDTO>> Get(CityFilterDTO filterDTO = null);
        Task<CityDTO> Create(CityDTO city);
    }
}