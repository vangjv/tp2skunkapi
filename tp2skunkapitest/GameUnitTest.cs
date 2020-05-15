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
        public void TestGame()
        {
            Assert.Fail();
        }

		public void TestVictory()
		{
			Player test_player_one = new Player("Player_One", 100, 50);
			Player test_player_two = new Player("Player_Two", 10, 50);
			Die test_die = new CrookedDie(5);
			Dice test_dice = new Dice(test_die, test_die);
			List<Player> playerList = new List<Player>();
			playerList.Add(test_player_one);
			playerList.Add(test_player_two);
			Game test_game = new Game(playerList, 2, test_dice);
			test_game.checkForVictory();
			Assert.AreEqual(test_game.isVictory(), true);
		}

	}
}
