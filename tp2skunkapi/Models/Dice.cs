using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp2skunkapi.Models
{
    public class Dice
    {
        private int lastRoll;
        private Die die1;
        private Die die2;
        private SkunkType skunkType;
        public Dice()
        {
            this.die1 = new Die();
            this.die2 = new Die();
            this.roll();
        }

		public Dice(Die die1, Die die2) // overloaded constructor
		{
			this.die1 = die1;
			this.die2 = die2;
		}

		public Dice(Die die1, int die1Value, Die die2, int die2Value) // overloaded constructor
		{
			this.die1 = die1;
			this.die2 = die2;

			this.lastRoll = die1Value + die2Value;

		}

		public int getLastRoll()
		{
			return this.lastRoll;
		}

		public void roll()
		{
			die1.roll();
			die2.roll();
			setSkunkType(die1, die2);
			this.lastRoll = die1.getLastRoll() + die2.getLastRoll();
		}

		public void setSkunkType(Die die1, Die die2)
		{
			if (die1.getLastRoll() == 1 && die2.getLastRoll() == 1)
			{
				skunkType = SkunkType.DOUBLE;
			}
			else if ((die1.getLastRoll() == 1 && die2.getLastRoll() != 2) || (die2.getLastRoll() == 1 && die1.getLastRoll() != 2))
			{
				skunkType = SkunkType.SINGLE;
			}
			else if ((die1.getLastRoll() == 1 && die2.getLastRoll() == 2) || (die2.getLastRoll() == 1 && die1.getLastRoll() == 2))
			{
				skunkType = SkunkType.SKUNKDUECE;
			}
			else
			{
				skunkType = SkunkType.NONE;
			}
		}

		public SkunkType getSkunkType()
		{
			return skunkType;
		}

		public Die getDie1()
		{
			return die1;
		}

		public Die getDie2()
		{
			return die2;
		}
	}
}
