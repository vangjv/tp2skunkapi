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
        public TurnDAO turnObject;
        public GameDAO(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
            turnObject = new TurnDAO(memoryCache);
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
            turnObject.createNewTurn(newGame.getAllPlayers()[newGame.turnSeriesTracker]);
        }

        public void processNewTurn()
        {
            Game currentGame = (Game)_cache.Get("currentGame");
        }

        public List<Player> getPlayers()
        {
            Game currentGame = (Game)_cache.Get("currentGame");
            return currentGame.getAllPlayers();
        }

        public void incrementPlayerTracker()
        {
            Game currentGame = (Game)_cache.Get("currentGame");
            currentGame.incrementTurnSeriesTracker();
        }

        public bool endOfTurnSeries()
        {
            Game currentGame = (Game)_cache.Get("currentGame");
            if (currentGame.turnSeriesTracker == (currentGame.players.Count - 1)) {
                return true;
            } else
            {
                return false;
            }               
        }
        
        public void checkForVictory()
        {
            Game currentGame = (Game)_cache.Get("currentGame");
            currentGame.checkForVictory();
        }

        public bool isVictory()
        {
            Game currentGame = (Game)_cache.Get("currentGame");
            currentGame.checkForVictory();
            if (currentGame.turnSeriesTracker == (currentGame.players.Count - 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
