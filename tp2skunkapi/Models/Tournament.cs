using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tp2skunkapi.Models
{
    public class Tournament
    {
		public List<Game> gameSeries;
		public List<Player> currentPlayerStatus;
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

		public bool checkForTournamentEnd()
		{
			return false;
		}

	}
}
