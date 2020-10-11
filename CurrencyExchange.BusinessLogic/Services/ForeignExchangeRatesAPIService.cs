using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using CurrencyExchange.BusinessLogic.Interfaces;
using CurrencyExchange.DataAccess.Interfaces;
using CurrencyExchange.Domains.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CurrencyExchange.Domains.DataTransferObjects.Currency;
using CurrencyExchange.Domains.DataTransferObjects.ForeignExchangeRatesAPI;
using Newtonsoft.Json;

namespace CurrencyExchange.BusinessLogic.Services
{
    public class ForeignExchangeRatesAPIService : IForeignExchangeRatesAPIService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<ForeignExchangeRatesAPIService> _logger;
        private readonly ICurrencyService _currencyService;
        private readonly ICityService _cityService;
        private readonly ForeignExchangeRatesAPISettings _exchangeAPISettings;

        public ForeignExchangeRatesAPIService(IUnitOfWork unitOfWork, IMapper mapper, IOptions<ForeignExchangeRatesAPISettings> exchangeAPISettings,
            ILogger<ForeignExchangeRatesAPIService> logger,
            ICurrencyService currencyService,
            ICityService cityService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _currencyService = currencyService;
            _cityService = cityService;
            _exchangeAPISettings = exchangeAPISettings.Value;
        }

        public async Task<IEnumerable<CurrencyDTO>> GetRatesFromAPI()
        {
            var currencies = new List<CurrencyDTO>();
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(_exchangeAPISettings.DefaultFetchRatesUrl),
                Method = HttpMethod.Get
            };

            using var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var currenciesDTO = JsonConvert.DeserializeObject<ForeignExchangeRatesDTO>(responseString);

                foreach (var rate in currenciesDTO.Rates)
                {
                    var rateDTO = new CurrencyDTO()
                    {
                        Code = rate.Key,
                        Rate = rate.Value,
                    };
                    currencies.Add(rateDTO);
                }

            }
            else
            {
                _logger.LogWarning("Error while fetching currency rates.", await response.Content.ReadAsStringAsync());
            }
            return currencies;

        }

        public async Task<bool> UpdateAllCurrenciesByCities()
        {
            var rates = (await GetRatesFromAPI()).ToList();
            var cities = await _cityService.Get();
            rates.RemoveAll(r => r.Code.ToLower() == "usd");
            foreach (var city in cities)
            {
                foreach (var rate in rates)
                {
                    var newCityRate = (CurrencyDTO)rate.Clone();
                    newCityRate.Rate = newCityRate.Rate * city.Ratio;
                    newCityRate.CityId = city.Id;
                    await _currencyService.Create(newCityRate);
                }
            }
            return true;
        }
    }
}