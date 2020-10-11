using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyExchange.BusinessLogic.Interfaces;
using CurrencyExchange.Domains.DataTransferObjects.City;
using CurrencyExchange.Domains.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange.Web.Controllers.api
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [AllowAnonymous]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]CityFilterDTO cityFilter)
        {
            return new JsonResult(await _cityService.Get());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CityDTO city)
        {
           var result = await _cityService.Create(city);
           return new JsonResult(result);
        }
    }
}
