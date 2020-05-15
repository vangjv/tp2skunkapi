using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp2skunkapi.Models
{
    public class NoSkunkDie : IDie
    {
		private int lastRoll;
		public NoSkunkDie()
		{
			roll();
		}

		public NoSkunkDie(int diceValue)
		{
			lastRoll = diceValue;
		}

		public int getLastRoll() 
		{
			return lastRoll;
		}

		public void roll() 
		{
			Random random = new Random();
			lastRoll = random.Next(1, 6);
			if (lastRoll == 1)
			{
				roll();
			}
		}
	}
}
