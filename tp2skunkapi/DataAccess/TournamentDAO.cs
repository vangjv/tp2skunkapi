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
        }

        public void createNewTournament(InitializeRequest initializeRequest)
        {
            cache.Set("rules", Initializer.getRules());
        }
    }
}
