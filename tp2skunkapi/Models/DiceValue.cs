using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp2skunkapi.Models
{
    public class DiceValue
    {
        public int dice1Value { get; set; }
        public int dice2Value { get; set; }
        public DiceValue(int value1, int value2)
        {
            dice1Value = value1;
            dice2Value = value2;
        }
    }
}
