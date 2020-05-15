using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp2skunkapi.Models
{
    public class Turn 
    {
		public Player player { get; set; }
		public int turnScore { get; set; }
		public Dice gameDice { get; set; }
		public List<DiceValue> rollSequence { get; set; }
		public int chipsToKitty { get; set; }
		public bool hasAnotherRoll { get; set; }

		public Turn(Player player, Dice gameDice)
		{
			this.player = player;
			this.gameDice = gameDice;
			rollSequence = new List<DiceValue>();
			turnScore = 0;
			chipsToKitty = 0;
			hasAnotherRoll = true;
		}

		public Turn(Player player)
		{
			this.player = player;
			this.gameDice = new Dice();
			rollSequence = new List<DiceValue>();
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
				rollSequence.Add(new DiceValue(gameDice.getDie1().lastRoll, gameDice.getDie2().lastRoll));
				hasAnotherRoll = false;
			}
			else if (gameDice.getSkunkType() == SkunkType.SKUNKDUECE)
			{ // skunk deuce
				player.skunkDeuce();
				turnScore = 0;
				chipsToKitty = 2;
				rollSequence.Add(new DiceValue(gameDice.getDie1().lastRoll, gameDice.getDie2().lastRoll));
				hasAnotherRoll = false;
			}
			else if (gameDice.getSkunkType() == SkunkType.SINGLE)
			{ //single skunk
				player.singleSkunk();
				turnScore = 0;
				chipsToKitty = 1;
				rollSequence.Add(new DiceValue(gameDice.getDie1().lastRoll, gameDice.getDie2().lastRoll));
				hasAnotherRoll = false;
			}
			else
			{ //add score to turnScore
				turnScore = turnScore + rollValue;
				rollSequence.Add(new DiceValue(gameDice.getDie1().lastRoll, gameDice.getDie2().lastRoll));
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
			hasAnotherRoll = false;
		}

		public int getChipsToKitty()
		{
			return chipsToKitty;
		}

		public Player getCurrentPlayer()
		{
			return player;
		}
	}
}
