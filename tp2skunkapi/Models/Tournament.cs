using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp2skunkapi.Models
{
    public class Tournament
    {
		private List<Game> gameSeries;
		private List<Player> currentPlayerStatus;
		public Tournament()
		{
			gameSeries = new List<Game>();
		}

		public Tournament(List<Game> games)
		{
			gameSeries = games;
			currentPlayerStatus = gameSeries[gameSeries.Count - 1].getAllPlayers();
		}

		public int getChipLeaderIndex()
		{
			var greatestIndex = 0;
			for (int i = 1; i < currentPlayerStatus.Count(); i++)
			{
				if (currentPlayerStatus[i].getChipCount() > currentPlayerStatus[greatestIndex].getChipCount())
				{
					greatestIndex = i;
				}
			}
			return greatestIndex;
		}

		public Player getChipLeader()
		{
			return currentPlayerStatus[getChipLeaderIndex()];
		}

		public void addGameToSeries(Game game)
		{
			gameSeries.Add(game);
			currentPlayerStatus = game.getAllPlayers();
		}

		public bool checkForTournamentEnd()
		{
			bool playerHasNoChips = false;
			bool player150Chips = false;
			for (int i = 0; i < currentPlayerStatus.Count(); i++)
			{
				if (currentPlayerStatus[i].getChipCount() == 0)
				{
					playerHasNoChips = true;
				}

				if (currentPlayerStatus[i].getChipCount() >= 150)
				{
					player150Chips = true;
				}
			}
			return playerHasNoChips || player150Chips;
		}

		public List<Player> getCurrentPlayerStatus()
		{
			return currentPlayerStatus;
		}

		public List<Game> getGameSeries()
		{
			return gameSeries;
		}

		public int getGameSeriesCount()
		{
			return gameSeries.Count;
		}

	}
}
