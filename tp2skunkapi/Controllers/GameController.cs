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
    public class SkunkController : ControllerBase
    {
        private RulesDAO rulesAccess;
        private TournamentDAO tournamentObject;
        private GameDAO gameObject;
        private TurnDAO turnObject;
        public SkunkController(IMemoryCache memoryCache)
        {
            rulesAccess = new RulesDAO(memoryCache);
            tournamentObject = new TournamentDAO(memoryCache);
            gameObject = new GameDAO(memoryCache);
            turnObject = new TurnDAO(memoryCache);
        }

        [HttpGet]
        [Route("rules")]
        public string Get()
        {
            return rulesAccess.getRules();
        }

        [HttpPost("initialize")]
        public InitializeRequest Initialize([FromBody]InitializeRequest initializeRequest)
        {
            if (initializeRequest.GameMode == "Tournament")
            {
                //initialize tournament
            } else
            {
                //initialize single game
                
            }
            return initializeRequest;
        }
    }
}
