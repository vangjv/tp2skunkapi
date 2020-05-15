using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp2skunkapi.DataAccess
{
    public class SkunkOptionsDAO
    {
        private readonly IMemoryCache _cache;
        public SkunkOptionsDAO(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }
        
        public void setGameMode(string gameMode)
        {
            _cache.Set("gameMode", gameMode);
        }

        public String getGameMode()
        {
            return (String)_cache.Get("gameMode");
        }

    }
}
