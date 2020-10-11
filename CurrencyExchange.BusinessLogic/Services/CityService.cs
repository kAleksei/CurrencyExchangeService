using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CurrencyExchange.BusinessLogic.Interfaces;
using CurrencyExchange.DataAccess.Interfaces;
using CurrencyExchange.DataAccess.Interfaces.Repositories;
using CurrencyExchange.Domains.DataTransferObjects.City;
using CurrencyExchange.Domains.Entities;

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

        public async Task<IEnumerable<CityDTO>> Get(CityFilterDTO filterDTO = null)
        {
            var cities = await _unitOfWork.GetRepository<ICityRepository>().Get(filterDTO);
            return _mapper.Map<IEnumerable<CityDTO>>(cities);
        }

        public async Task<CityDTO> Create(CityDTO city)
        {
            var entity = _mapper.Map<City>(city);
            entity.CreateTime = DateTime.Now;
            entity.ChangeTime = DateTime.Now;
            await _unitOfWork.GetRepository<ICityRepository>().Insert(entity);
            await _unitOfWork.Save();
            return _mapper.Map<CityDTO>(entity);
        }
    }
}