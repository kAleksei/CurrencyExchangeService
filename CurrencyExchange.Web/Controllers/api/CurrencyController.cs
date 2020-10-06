using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public CurrencyController()
        {
            
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new JsonResult("Hello");
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return new JsonResult("Hello");
        }

    }
}
