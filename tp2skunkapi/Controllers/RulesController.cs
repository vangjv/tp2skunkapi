﻿using System;
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
        private RulesDAO rulesAccess;
        public RulesController(IMemoryCache memoryCache)
        {
            rulesAccess = new RulesDAO(memoryCache);
        }

        [HttpGet]
        public string Get()
        {
            return rulesAccess.getRules();
        }
    }
}
