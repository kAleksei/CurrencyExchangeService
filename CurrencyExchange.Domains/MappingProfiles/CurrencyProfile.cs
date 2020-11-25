using CurrencyExchange.Domains.DataTransferObjects.Currency;
using CurrencyExchange.Domains.Entities;

namespace CurrencyExchange.Domains.MappingProfiles
{
    public class CurrencyProfile : AutoMapper.Profile
    {
        public CurrencyProfile()
        {
            CreateMap<Currency, CurrencyDTO>()
                .ForMember(c => c.Code, opt => opt.MapFrom(c => c.CurrencyCode))
                .ForMember(c => c.LastUpdate, opt => opt.MapFrom(c => c.ChangeTime))
                .ForMember(c => c.Balance, opt => opt.MapFrom(c => c.CurrencyBalance.Balance))
                .ForMember(c => c.LastBalanceUpdate, opt => opt.MapFrom(c => c.CurrencyBalance.ChangeTime));

            CreateMap<CurrencyDTO, Currency>()
                .ForMember(c => c.CurrencyCode, opt => opt.MapFrom(c => c.Code))
                .ForMember(c => c.ChangeTime, opt => opt.MapFrom(c => c.LastUpdate));

            CreateMap<Currency, CurrencyArchive>()
                .ForMember(c => c.CurrencyId, opt => opt.MapFrom(c => c.Id));
            CreateMap<CurrencyArchive, Currency>().ForAllMembers(opt => opt.AllowNull());
        }

    }
}