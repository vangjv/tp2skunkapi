using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using tp2skunkapi.Models;

namespace tp2skunkapitest
{
    [TestClass]
    public class GameUnitTest
    {
		[TestMethod]
		public void TestVictory()
		{
			Player test_player_one = new Player("Player_One", 100, 50);
			Player test_player_two = new Player("Player_Two", 10, 50);
			Die test_die = new CrookedDie(5);
			Dice test_dice = new Dice(test_die, test_die);
			List<Player> playerList = new List<Player>();
			playerList.Add(test_player_one);
			playerList.Add(test_player_two);
			Game test_game = new Game(playerList, test_dice);
			test_game.checkForVictory();
			Assert.AreEqual(test_game.isVictory(), true);
		}

		[TestMethod]
		public void TestNoVictory()
		{
			Player test_player_one = new Player("Player_One", 70, 50);
			Player test_player_two = new Player("Player_Two", 10, 50);
			Die test_die = new CrookedDie(5);
			Dice test_dice = new Dice(test_die, test_die);
			List<Player> playerList = new List<Player>();
			playerList.Add(test_player_one);
			playerList.Add(test_player_two);
			Game test_game = new Game(playerList, test_dice);
			test_game.checkForVictory();
			Assert.AreEqual(test_game.isVictory(), false);
		}

		[TestMethod]
		public void TestLeaderCheck()
		{
			Player test_player_one = new Player("Player_One", 70, 50);
			Player test_player_two = new Player("Player_Two", 10, 50);
			Player test_player_three = new Player("Player_Three", 80, 50);
			Player test_player_four = new Player("Player_Four", 50, 50);
			Die test_die = new CrookedDie(5);
			Dice test_dice = new Dice(test_die, test_die);
			List<Player> playerList = new List<Player>();
			playerList.Add(test_player_one);
			playerList.Add(test_player_two);
			playerList.Add(test_player_three);
			playerList.Add(test_player_four);
			Game test_game = new Game(playerList, test_dice);
			int leaderIndex = test_game.findLeaderIndex();
			Assert.AreEqual(2, leaderIndex);
		}

		[TestMethod]
		public void TestProcessChipsForWinner()
		{
			Player test_player_one = new Player("Player_One", 100, 50);
			Player test_player_two = new Player("Player_Two", 10, 40);
			Player test_player_three = new Player("Player_Three", 0, 50);
			Die test_die = new CrookedDie(5);
			Dice test_dice = new Dice(test_die, test_die);
			List<Player> playerList = new List<Player>();
			playerList.Add(test_player_one);
			playerList.Add(test_player_two);
			playerList.Add(test_player_three);
			Game test_game = new Game(playerList, test_dice);
			test_game.checkForVictory();
			test_game.setKittyCount(10);
			test_game.processChipsForWinner();
			Assert.AreEqual(test_player_one.getChipCount(), 75);
			Assert.AreEqual(test_player_two.getChipCount(), 35);
			Assert.AreEqual(test_player_three.getChipCount(), 40);
		}

	}
}
