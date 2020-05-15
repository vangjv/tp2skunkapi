using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp2skunkapi.Models
{
    public class Turn 
    {
		private Player player;
		private int turnScore;
		private Dice gameDice;
		private List<int> rollSequence;
		private int chipsToKitty;
		private bool hasAnotherRoll;

		public Turn(Player player, Dice gameDice)
		{
			this.player = player;
			this.gameDice = gameDice;
			rollSequence = new List<int>();
			turnScore = 0;
			chipsToKitty = 0;
			hasAnotherRoll = true;
		}

		public int getTurnScore()
		{
			return turnScore;
		}

		public void setTurnScore(int turnScore)
		{
			this.turnScore = turnScore;
		}

		public void processRoll()
		{
			gameDice.roll();
			int rollValue = gameDice.getLastRoll();
			if (gameDice.getSkunkType() == SkunkType.DOUBLE)
			{ //double skunk
				player.doubleSkunk();
				turnScore = 0;
				chipsToKitty = 4;
				rollSequence.Add(-4);
				hasAnotherRoll = false;
			}
			else if (gameDice.getSkunkType() == SkunkType.SKUNKDUECE)
			{ // skunk deuce
				player.skunkDeuce();
				turnScore = 0;
				chipsToKitty = 2;
				rollSequence.Add(-2);
				hasAnotherRoll = false;
			}
			else if (gameDice.getSkunkType() == SkunkType.SINGLE)
			{ //single skunk
				player.singleSkunk();
				turnScore = 0;
				chipsToKitty = 1;
				rollSequence.Add(-1);
				hasAnotherRoll = false;
			}
			else
			{ //add score to turnScore
				turnScore = turnScore + rollValue;
				rollSequence.Add(rollValue);
				hasAnotherRoll = true;
			}
		}

		public void passTurn()
		{
			summarizeTurn();
		}

		public void summarizeTurn()
		{
			player.addScore(turnScore);
		}

		public int getChipsToKitty()
		{
			return chipsToKitty;
		}
	}
}
