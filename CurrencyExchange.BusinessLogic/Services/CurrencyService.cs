using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CurrencyExchange.BusinessLogic.Interfaces;
using CurrencyExchange.DataAccess.Interfaces;
using CurrencyExchange.DataAccess.Interfaces.Repositories;
using CurrencyExchange.Domains.DataTransferObjects.Currency;
using CurrencyExchange.Domains.Entities;

namespace CurrencyExchange.BusinessLogic.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CurrencyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public virtual async Task<IEnumerable<CurrencyDTO>> Get(CurrencyFilterDTO filteringModel = null)
        {
            var currencies = await _unitOfWork.GetRepository<ICurrencyRepository>().Get(filteringModel);
            var result = _mapper.Map<IEnumerable<CurrencyDTO>>(currencies);
            return result;
        }

        public virtual async Task<CurrencyDTO> Create(CurrencyDTO currency)
        {
            if (currency == null) throw new ArgumentNullException(nameof(currency));
            var entity = _mapper.Map<Currency>(currency);
            var result = await _unitOfWork.GetRepository<ICurrencyRepository>().Insert(entity);
            await _unitOfWork.Save();
            return _mapper.Map<CurrencyDTO>(result);
        }

        public virtual async Task<CurrencyDTO> Update(CurrencyDTO currency)
        {
            var entity = _mapper.Map<Currency>(currency);
            await _unitOfWork.GetRepository<ICurrencyRepository>().Update(entity);
            await _unitOfWork.Save();
            var result = _mapper.Map<CurrencyDTO>(entity);
            return result;
        }

        public virtual async Task Delete(int id)
        {
            await _unitOfWork.GetRepository<ICurrencyRepository>().Delete(id);
            await _unitOfWork.Save();
        }
    }
}