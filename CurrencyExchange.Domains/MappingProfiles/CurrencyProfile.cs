using CurrencyExchange.Domains.DataTransferObjects.Currency;
using CurrencyExchange.Domains.Entities;

namespace CurrencyExchange.Domains.MappingProfiles
{
    public class CurrencyProfile : AutoMapper.Profile
    {
        public CurrencyProfile()
        {
            CreateMap<Currency, CurrencyDTO>()
                .ForMember(c => c.Code, opt => opt.MapFrom(c => c.CurrencyCode));

            CreateMap<CurrencyDTO, Currency>()
                .ForMember(c => c.CurrencyCode, opt => opt.MapFrom(c => c.Code));

            CreateMap<Currency, CurrencyArchive>()
                .ForMember(c => c.CurrencyId, opt => opt.MapFrom(c => c.Id));
            CreateMap<CurrencyArchive, Currency>().ForAllMembers(opt => opt.AllowNull());
        }

    }
}