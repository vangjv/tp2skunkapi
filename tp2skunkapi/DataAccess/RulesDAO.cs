using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp2skunkapi.DataAccess
{
    public class RulesDAO
    {
        private readonly IMemoryCache _cache;
        public RulesDAO(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }
        
        public string getRules()
        {
            return _cache.Get("rules").ToString();
        }


    }
}
