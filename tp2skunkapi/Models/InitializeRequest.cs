using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp2skunkapi.Models
{
    public class InitializeRequest
    {
        public String[] PlayerNames { get; set; }
        public string GameMode { get; set; }
    }
}
