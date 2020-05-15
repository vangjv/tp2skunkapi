using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp2skunkapi.Models;

namespace tp2skunkapi.DataAccess
{
    public class TournamentDAO
    {
        private readonly IMemoryCache _cache;
        public TournamentDAO(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
            Tournament currentTournament = new Tournament();
            _cache.Set("currentTournament", currentTournament);
        }

        public bool isNewTournament()
        {
            Tournament currentTournament = (Tournament)_cache.Get("currentTournament");
            if (currentTournament.getGameSeriesCount() < 1)
            {
                return true;
            } else
            {
                return false;
            }
        }
        
    }
}
