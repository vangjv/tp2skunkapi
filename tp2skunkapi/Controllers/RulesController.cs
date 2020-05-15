using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using tp2skunkapi.DataAccess;

namespace tp2skunkapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RulesController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private RulesAccess rulesAccess;
        public RulesController(ILogger<WeatherForecastController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            rulesAccess = new RulesAccess(memoryCache);
        }

        [HttpGet]
        public string Get()
        {
            return rulesAccess.getRules();
        }
    }
}
