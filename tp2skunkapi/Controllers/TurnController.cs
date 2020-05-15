using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using tp2skunkapi.DataAccess;
using tp2skunkapi.Models;

namespace tp2skunkapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TurnController : ControllerBase
    {
        private TurnDAO turnObject;
        public TurnController(IMemoryCache memoryCache)
        {
            turnObject = new TurnDAO(memoryCache);
            turnObject.createNewTurn(new Player("Jon", 50, 50));
        }

        [HttpGet]
        [Route("currentTurnPlayer")]
        public ActionResult Get()
        {
            return Ok(turnObject.getCurrentPlayer());
        }
        
    }
}
