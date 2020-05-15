using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using tp2skunkapi.Models;

namespace tp2skunkapitest
{
    [TestClass]
    public class TurnUnitTest
    {

		[TestMethod]
		public void test_getTurnScore()
		{
			Player test_player_one = new Player("Player_One", 50, 50);
			//use two predictable dice to get turn score
			Die test_die = new CrookedDie(1);
			Dice test_dice = new Dice(test_die, test_die);
			Turn test_turn = new Turn(test_player_one, test_dice);
			//two dice with a set value of 5 were used.
			Assert.AreEqual(test_turn.getTurnScore(), 0);
		}

		[TestMethod]
		public void test_processRoll()
		{
			Player test_player_one = new Player("Player_One", 50, 50);
			//use two predictable dice to get turn score
			Die test_die = new CrookedDie(5);
			Dice test_dice = new Dice(test_die, test_die);
			Turn test_turn = new Turn(test_player_one, test_dice);
			test_turn.processRoll();
			//two dice with a set value of 5 were used.
			Assert.AreEqual(test_turn.getTurnScore(), 10);
			test_turn.setTurnScore(15);
			Assert.AreEqual(test_turn.getTurnScore(), 15);
		}

		[TestMethod]
	public void test_turnScore()
		{
			Player test_player_one = new Player("Player_One", 50, 50);
			//use two predictable dice to get turn score
			Die test_die = new CrookedDie(5);
			Dice test_dice = new Dice(test_die, test_die);
			Turn test_turn = new Turn(test_player_one, test_dice);
			test_turn.setTurnScore(15);
			//two dice with a set value of 5 were used.
			Assert.AreEqual(test_turn.getTurnScore(), 15);
		}

		[TestMethod]
		public void test_SummarizeTurn()
		{
			Player test_player_one = new Player("Player_One", 50, 50);
			//use two predictable dice to get turn score
			Die test_die = new CrookedDie(5);
			Dice test_dice = new Dice(test_die, test_die);
			Turn test_turn = new Turn(test_player_one, test_dice);
			test_turn.processRoll();
			test_turn.summarizeTurn();
			//two dice with a set value of 5 were used.
			Assert.AreEqual(test_turn.getTurnScore(), 10);
		}

		[TestMethod]
		public void test_double_skunk()
		{
			Player test_player_one = new Player("Player_One", 50, 50);
			//use two predictable dice to get turn score
			//test DOUBLE Skunk
			Die test_die = new CrookedDie(1);
			Dice test_dice = new Dice(test_die, test_die);
			Turn test_turn = new Turn(test_player_one, test_dice);
			test_turn.setTurnScore(10);
			//ensure a turn score is added before its removed by double skunk
			Assert.AreEqual(test_turn.getTurnScore(), 10);
			test_turn.processRoll();
			Assert.AreEqual(test_turn.getChipsToKitty(), 4);
			Assert.AreEqual(test_turn.getTurnScore(), 0);
		}

		[TestMethod]
		public void test_skunk_duece()
		{
			Player test_player_one = new Player("Player_One", 50, 50);
			//use two predictable dice to get turn score
			//test SKUNKDUECE
			Die test_die = new CrookedDie(1);
			Die test_die_two = new CrookedDie(2);
			Dice test_dice = new Dice(test_die, test_die_two);
			Turn test_turn = new Turn(test_player_one, test_dice);
			test_turn.setTurnScore(10);
			//ensure a turn score is added before its removed by skunk duece
			Assert.AreEqual(test_turn.getTurnScore(), 10);
			test_turn.processRoll();
			Assert.AreEqual(test_turn.getChipsToKitty(), 2);
			Assert.AreEqual(test_turn.getTurnScore(), 0);
		}

		[TestMethod]
		public void test_single_skunk()
		{
			Player test_player_one = new Player("Player_One", 50, 50);
			//use two predictable dice to get turn score
			//test SKUNKDUECE
			Die test_die = new CrookedDie(1);
			Die test_die_two = new CrookedDie(3);
			Dice test_dice = new Dice(test_die, test_die_two);
			Turn test_turn = new Turn(test_player_one, test_dice);
			test_turn.setTurnScore(10);
			//ensure a turn score is added before its removed by single skunk
			Assert.AreEqual(test_turn.getTurnScore(), 10);
			test_turn.processRoll();
			Assert.AreEqual(test_turn.getChipsToKitty(), 1);
			Assert.AreEqual(test_turn.getTurnScore(), 0);
		}

		[TestMethod]
		public void test_no_penalty()
		{
			Player test_player_one = new Player("Player_One", 50, 50);
			//use two predictable dice to get turn score
			Die test_die = new CrookedDie(3);
			Dice test_dice = new Dice(test_die, test_die);
			Turn test_turn = new Turn(test_player_one, test_dice);
			test_turn.setTurnScore(10);
			Assert.AreEqual(test_turn.getTurnScore(), 10);
			test_turn.processRoll();
			//rolling adds on die values to already sety turn score.
			Assert.AreEqual(test_turn.getChipsToKitty(), 0);
			Assert.AreEqual(test_turn.getTurnScore(), 16);
		}

	}
}
