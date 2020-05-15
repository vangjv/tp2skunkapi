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
        }

        [HttpGet]
        [Route("createNewTurn")]
        public ActionResult createNewTurn()
        {
            turnObject.createNewTurn(new Player("Jon", 50, 50));
            return Ok(turnObject.getCurrentPlayer());
        }

        [HttpGet]
        [Route("currentTurnPlayer")]
        public ActionResult getCurrentPlayer()
        {
            return Ok(turnObject.getCurrentPlayer());
        }

        [HttpGet]
        [Route("processRoll")]
        public ActionResult processRoll()
        {
            turnObject.processTurnRoll();
            return Ok(turnObject.getCurrentPlayer());
        }

        [HttpGet]
        [Route("currentTurnExist")]
        public ActionResult currentTurnExist()
        {
           
            return Ok(turnObject.currentTurnExist());
        }

        [HttpGet]
        [Route("getCurrentTurn")]
        public ActionResult getCurrentTurn()
        {
            return Ok(turnObject.getCurrentTurn());
        }

    }
}
