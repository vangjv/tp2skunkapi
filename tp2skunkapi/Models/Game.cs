using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp2skunkapi.Models
{
    public class Game
    {
		private List<Player> players;
		public List<Player> playersWithScoreOver100 = new List<Player>();
		private List<Turn> gameSeries;
		private int kittyCount = 0;
		private Dice gameDice;
		private bool victory = false;

		public Game(List<string> playerNames, Dice diceUsed)
		{
			gameSeries = new List<Turn>();
			gameDice = diceUsed;
			players = new List<Player>();
			playerNames.ForEach(playerName =>
			{
				players.Add(new Player(playerName, 0, 50));
			});
		}

		public Game(List<Player> playerInitialized, Dice diceUsed)
		{
			gameSeries = new List<Turn>();
			gameDice = diceUsed;
			players = new List<Player>();
			players = playerInitialized;
		}

		public Game(List<Player> playerInitialized)
		{
			gameSeries = new List<Turn>();
			gameDice = new Dice();
			players = new List<Player>();
			players = playerInitialized;
		}

		public void addTurnToSeries(Turn turn)
		{
			gameSeries.Add(turn);
		}

		public void checkForVictory()
		{
			players.ForEach(player => {
				if (player.getScore() >= 100)
				{
					playersWithScoreOver100.Add(player);
					victory = true;
				}
			});
		}

		public void processChipsForWinner()
		{
			int winnerIndex = findLeaderIndex();
			for (int i = 0; i < players.Count(); i++)
			{
				if (i == winnerIndex)
				{
					//winner, add chips
					players[winnerIndex].addChips(kittyCount);
				}
				else
				{
					//losers, deduct and add to winner
					if (players[i].getScore() <= 0)
					{
						players[i].removeChips(10);
						players[winnerIndex].addChips(10);
					}
					else
					{
						players[i].removeChips(5);
						players[winnerIndex].addChips(5);
					}
				}
			}
		}

		public int findLeaderIndex()
		{
			var greatestIndex = 0;
			for (int i = 1; i < players.Count(); i++)
			{
				if (players[i].getScore() > players[greatestIndex].getScore())
				{
					greatestIndex = i;
				}
			}
			return greatestIndex;
		}

		public Player getLeader()
		{
			return players[findLeaderIndex()];
		}

		public void setKittyCount(int kitty)
		{
			kittyCount = kitty;
		}

		public bool isVictory()
		{
			return victory;
		}

		public List<Player> getAllPlayers()
		{
			return players;
		}

	}
}
