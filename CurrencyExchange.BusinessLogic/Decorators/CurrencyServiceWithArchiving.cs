using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CurrencyExchange.BusinessLogic.Interfaces;
using CurrencyExchange.BusinessLogic.Services;
using CurrencyExchange.DataAccess.Interfaces;
using CurrencyExchange.DataAccess.Interfaces.Repositories;
using CurrencyExchange.Domains.DataTransferObjects.Currency;
using CurrencyExchange.Domains.Entities;

namespace CurrencyExchange.BusinessLogic.Decorators
{
    public class CurrencyServiceWithArchiving : CurrencyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrencyService _wrappedCurrencyService;

        public CurrencyServiceWithArchiving(IUnitOfWork unitOfWork, IMapper mapper, ICurrencyService wrappedCurrencyService) : base(unitOfWork, mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _wrappedCurrencyService = wrappedCurrencyService;
        }

        public override async Task<CurrencyDTO> Create(CurrencyDTO currency)
        {
            if (currency == null) throw new ArgumentNullException(nameof(currency));
            var currencyCode = currency.Code.ToLower();
            var entity = (await _unitOfWork.GetRepository<ICurrencyRepository>().Get(c => c.CurrencyCode == currencyCode)).FirstOrDefault();
            if (entity != null)
            {
                var currencyDTO = _mapper.Map<CurrencyDTO>(entity);
                if (entity.ChangeTime.Date < DateTime.Now.Date)
                {

                    entity.Rate = currency.Rate;
                    entity.ChangeTime = DateTime.Now;
                    await _unitOfWork.GetRepository<ICurrencyArchiveRepository>().Insert(_mapper.Map<CurrencyArchive>(entity));
                    await _wrappedCurrencyService.Update(currencyDTO);
                    return currencyDTO;
                }

                return currencyDTO;
            }
            else
            {
                var result = await _wrappedCurrencyService.Create(currency);
                return result;
            }
        }
    }
}