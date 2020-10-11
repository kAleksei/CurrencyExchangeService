using CurrencyExchange.Domains.DataTransferObjects.City;
using CurrencyExchange.Domains.Entities;

namespace CurrencyExchange.Domains.MappingProfiles
{
    public class CityProfile: AutoMapper.Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityDTO>()
                .ForMember(c => c.Name, opt => opt.MapFrom(c => c.CityName));
            CreateMap<CityDTO, City>()
                .ForMember(c => c.CityName, opt => opt.MapFrom(c => c.Name));
            ;
        }
    }
}