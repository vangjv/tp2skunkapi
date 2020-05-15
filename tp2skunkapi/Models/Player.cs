using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp2skunkapi.Models
{
    public class Player
    {
        public int score { get; set; }
		public int chipCount { get; set; }
		public String playerName { get; set; }
		public Player()
        {
            score = 0;
            chipCount = 100;
        }
        public Player(String playerName, int score, int chipCount)
        {
            this.playerName = playerName;
            this.score = score;
            this.chipCount = chipCount;
        }

		public void doubleSkunk()
		{
			score = 0;
			chipCount = chipCount - 4;
		}

		public void singleSkunk()
		{
			chipCount = chipCount - 1;
		}

		public void skunkDeuce()
		{
			chipCount = chipCount - 2;
		}

		public void addScore(int diceAmount)
		{
			score = score + diceAmount;
		}

		public int getScore()
		{
			return score;
		}

		public void setScore(int score)
		{
			this.score = score;
		}

		public int getChipCount()
		{
			return chipCount;
		}

		public void setChipCount(int chipCount)
		{
			this.chipCount = chipCount;
		}

		public void addChips(int chips)
		{
			chipCount = chipCount + chips;
		}

		public void removeChips(int chips)
		{
			chipCount = chipCount - chips;
		}

		public String getPlayerName()
		{
			return playerName;
		}

		public void setPlayerName(String playerName)
		{
			this.playerName = playerName;
		}

	}
}
