﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp2skunkapi.Models
{
    public class Die : IDie
    {
		public int lastRoll { get; set; }
		public Die()
		{
			this.roll();
		}

		public Die(int diceValue)
		{
			lastRoll = diceValue;
		}

		public int getLastRoll() 
		{
			return this.lastRoll;
		}

		public virtual void roll() 
		{
			Random random = new Random();
			this.lastRoll = random.Next(1, 7);
		}
	}
}
