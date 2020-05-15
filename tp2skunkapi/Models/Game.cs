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

		public Game(List<Player> players, int playerCount, Dice gameDice)
		{
			//this.players = players;
			//this.gameDice = gameDice;
			//gameSeries = new List<Turn>();
			////if no players are passed get names for number of players
			//if (players.Count() == 0)
			//{
			//	for (int i = 0; i < playerCount; i++)
			//	{
			//		players.Add(new Player(GamePL.getPlayerName(i), 0, 50));
			//	}
			//}
		}


	public void startGame()
		{
			//while (victory == false)
			//{
			//	startSeries();
			//	checkForVictory();
			//}
			////final turn for other players before declaring victory
			//GamePL.announceFinalRound(playersWithScoreOver100);
			//players.forEach((player)-> {
			//	if (player.getScore() < 100)
			//	{
			//		Turn finalTurn = new Turn(player, gameDice);
			//		finalTurn.processTurns();
			//		gameSeries.add(finalTurn);
			//		kittyCount = kittyCount + finalTurn.getChipsToKitty();
			//	}
			//});

			////sort players by score
			//Collections.sort(players);
			//processChipsForWinner();
			//GamePL.printVictoryScores(players);
		}

		public void startSeries()
		{
			////start turn series
			//players.forEach((player)-> {
			//	Turn newTurn = new Turn(player, gameDice);
			//	newTurn.processTurns();
			//	gameSeries.add(newTurn);
			//	kittyCount = kittyCount + newTurn.getChipsToKitty();
			//});
		}

		public void checkForVictory()
		{
			//players.forEach((player)-> {
			//	if (player.getScore() >= 100)
			//	{
			//		playersWithScoreOver100.add(player);
			//		victory = true;
			//	}
			//});
		}

		public void processChipsForWinner()
		{
			//for (int i = 0; i < players.size(); i++)
			//{
			//	if (i == 0)
			//	{
			//		//winner, add chips
			//		players.get(i).addChips(kittyCount);
			//	}
			//	else
			//	{
			//		//losers, deduct and add to winner
			//		if (players.get(i).getScore() <= 0)
			//		{
			//			players.get(i).removeChips(10);
			//			players.get(0).addChips(10);
			//		}
			//		else
			//		{
			//			players.get(i).removeChips(5);
			//			players.get(0).addChips(5);
			//		}
			//	}
			//}
		}

		public void setKittyCount(int kitty)
		{
			kittyCount = kitty;
		}

		public bool isVictory()
		{
			return victory;
		}

	}
}
