using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp2skunkapi.Models
{
    interface IDie
    {
        public int getLastRoll();
        public void roll();
    }
}
