using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.BusinessLogic.Interfaces;
using CurrencyExchange.Domains.DataTransferObjects.Currency;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange.Web.Controllers.api
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [AllowAnonymous]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;


        }
        
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]CurrencyFilterDTO filter)
        {
            var result = await _currencyService.Get(filter);
            return new JsonResult(result);
        }
    }
}
