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
        private SkunkOptionsDAO skunkOptions;
        public SkunkController(IMemoryCache memoryCache)
        {
            rulesAccess = new RulesDAO(memoryCache);
            tournamentObject = new TournamentDAO(memoryCache);
            gameObject = new GameDAO(memoryCache);
            turnObject = new TurnDAO(memoryCache);
            skunkOptions = new SkunkOptionsDAO(memoryCache);
        }

        [HttpGet]
        [Route("rules")]
        public ActionResult Get()
        {
            return Ok(rulesAccess.getRules());
        }

        [HttpPost("initialize")]
        public ActionResult Initialize([FromBody]InitializeRequest initializeRequest)
        {
            //set gamemode
            skunkOptions.setGameMode(initializeRequest.GameMode);
            if (initializeRequest.GameMode == "Tournament")
            {
                //initialize tournament
                tournamentObject.createNewTournament();
                gameObject.createNewGame(initializeRequest);
            } else
            {
                //initialize single game
                gameObject.createNewGame(initializeRequest);                
            }
            SkunkStatus skunkStatus = new SkunkStatus(turnObject.getCurrentTurn(),gameObject.getPlayers());
            return Ok(skunkStatus);
        }

        [HttpGet]
        [Route("roll")]
        public ActionResult Roll()
        {
            turnObject.processTurnRoll();
            //check if player has another turn
            if (turnObject.hasAnotherRoll())
            {
                SkunkStatus skunkStatus = new SkunkStatus(turnObject.getCurrentTurn(), gameObject.getPlayers());
                return Ok(skunkStatus);
            } else
            {
                //if end of turn series, check for victory
                if (gameObject.endOfTurnSeries())
                {
                    gameObject.checkForVictory();
                }
            }
        }
    }
}
