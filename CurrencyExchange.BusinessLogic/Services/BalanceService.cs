using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CurrencyExchange.BusinessLogic.Interfaces;
using CurrencyExchange.DataAccess.Interfaces;
using CurrencyExchange.DataAccess.Interfaces.Repositories;
using CurrencyExchange.Domains.DataTransferObjects.City;
using CurrencyExchange.Domains.DataTransferObjects.Currency;
using CurrencyExchange.Domains.Entities;
using CurrencyExchange.Domains.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CurrencyExchange.BusinessLogic.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrencyService _currencyService;
        private readonly CurrencyBalanceSettings _currencyBalanceSettings;


        public BalanceService(IUnitOfWork unitOfWork, IMapper mapper, ICurrencyService currencyService, IOptions<CurrencyBalanceSettings> currencyBalanceSettings)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currencyService = currencyService;
            _currencyBalanceSettings = currencyBalanceSettings.Value;
        }

        public async Task<bool> WithdrawAllBalances()
        {
            var currencies = await _unitOfWork.GetRepository<ICurrencyRepository>().Get(include: q => q.Include(q => q.CurrencyBalance));
            var random = new Random();
            foreach (var currency in currencies)
            {
                if (currency.CurrencyBalance != null)
                {
                    var withdraw = random.Next((int) (_currencyBalanceSettings.MaxWithdraw));
                    if (currency.CurrencyBalance.Balance - withdraw >= 0)
                    {
                        currency.CurrencyBalance.Balance -= withdraw;
                    }
                    currency.CurrencyBalance.ChangeTime = DateTime.Now;
                    await _unitOfWork.GetRepository<ICurrencyRepository>().Update(currency);
                    await _unitOfWork.Save();

                }
                else
                {
                    var currencyBalance = new CurrencyBalance()
                    {
                        Balance = 0,
                        ChangeTime = DateTime.Now,
                        CreateTime = DateTime.Now,
                        Currency = currency,
                        CurrencyId = currency.Id,
                    };
                    await _unitOfWork.GetRepository<IBalanceRepository>().Insert(currencyBalance);
                    await _unitOfWork.Save();

                }
            }

            return true;
        }

        public async Task<bool> DepositAllBalances()
        {
            var currencies = await _unitOfWork.GetRepository<ICurrencyRepository>().Get(include: q => q.Include(q => q.CurrencyBalance));
            var random = new Random();

            foreach (var currency in currencies)
            {
                if (currency.CurrencyBalance != null)
                {
                    var deposit = random.Next((int)_currencyBalanceSettings.MaxDeposit);
                    if (currency.CurrencyBalance.Balance + deposit <= _currencyBalanceSettings.MaxBalance)
                    {
                        currency.CurrencyBalance.Balance += deposit;
                        currency.CurrencyBalance.ChangeTime = DateTime.Now;
                    }
                    await _unitOfWork.GetRepository<ICurrencyRepository>().Update(currency);
                    await _unitOfWork.Save();
                }
                else
                {
                    var currencyBalance = new CurrencyBalance()
                    {
                        Balance = 0,
                        ChangeTime = DateTime.Now,
                        CreateTime = DateTime.Now,
                        Currency = currency,
                        CurrencyId = currency.Id,
                    };
                    await _unitOfWork.GetRepository<IBalanceRepository>().Insert(currencyBalance);
                    await _unitOfWork.Save();
                }
            }

            return true;
        }
    }
}