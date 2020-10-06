using AutoMapper;
using CurrencyExchange.BusinessLogic.Interfaces;
using CurrencyExchange.DataAccess.Interfaces;

namespace CurrencyExchange.BusinessLogic.Services
{
    public class CityService: ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}