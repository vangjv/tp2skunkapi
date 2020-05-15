using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp2skunkapi.Models;

namespace tp2skunkapi.DataAccess
{
    public class TurnDAO 
    {
        private readonly IMemoryCache _cache;
        public TurnDAO(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public bool currentTurnExist()
        {
            Turn currentTurn;
            return _cache.TryGetValue("currentTurn", out currentTurn);
        }

        public void createNewTurn(Player player)
        {
            Turn newTurn = new Turn(player);            
            _cache.Set("currentTurn", newTurn);
        }

        public Player getCurrentPlayer()
        {
            Turn currentTurn = (Turn)_cache.Get("currentTurn");
            return currentTurn.getCurrentPlayer();
        }

        public Turn getCurrentTurn()
        {
            Turn currentTurn = (Turn)_cache.Get("currentTurn");
            return currentTurn;
        }


        public void processTurnRoll()
        {
            Turn currentTurn = (Turn)_cache.Get("currentTurn");
            currentTurn.processRoll();
        }

        public bool hasAnotherRoll()
        {
            Turn currentTurn = (Turn)_cache.Get("currentTurn");
            return currentTurn.hasAnotherRoll;
        }

    }
}
