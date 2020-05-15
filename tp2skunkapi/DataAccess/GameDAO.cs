using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp2skunkapi.Models;

namespace tp2skunkapi.DataAccess
{
    public class GameDAO 
    {
        private readonly IMemoryCache _cache;
        public GameDAO(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public void createNewGame(InitializeRequest initializeRequest)
        {
            List<Player> playerList = new List<Player>();
            initializeRequest.PlayerNames.ForEach(playerName =>
            {
                playerList.Add(new Player(playerName, 0, 50));
            });
            Game newGame = new Game(playerList);
            _cache.Set("currentGame", newGame);
        }

        public void processNewTurn()
        {
            Game currentGame = (Game)_cache.Get("currentGame");
        }

    }
}
