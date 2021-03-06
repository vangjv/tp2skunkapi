﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using tp2skunkapi.Models;

namespace tp2skunkapitest
{
    [TestClass]
    public class TournamentUnitTest
    {
        [TestMethod]
        public void TestGetChipLeader()
        {
            Player test_player_one = new Player("Player_One", 70, 40);
            Player test_player_two = new Player("Player_Two", 10, 50);
            Player test_player_three = new Player("Player_Three", 80, 70);
            Player test_player_four = new Player("Player_Four", 50, 90);
            Die test_die = new CrookedDie(5);
            Dice test_dice = new Dice(test_die, test_die);
            List<Player> playerList = new List<Player>();
            playerList.Add(test_player_one);
            playerList.Add(test_player_two);
            playerList.Add(test_player_three);
            playerList.Add(test_player_four);
            Game test_game = new Game(playerList, test_dice);
            List<Game> gameSeries = new List<Game>();
            gameSeries.Add(test_game);
            Tournament testTournament = new Tournament(gameSeries);
            int chipLeaderIndex = testTournament.getChipLeaderIndex();
            Assert.AreEqual(3, chipLeaderIndex);
        }

        [TestMethod]
        public void TestCheckForTournamentNoEnd()
        {
            Player test_player_one = new Player("Player_One", 70, 40);
            Player test_player_two = new Player("Player_Two", 10, 50);
            Player test_player_three = new Player("Player_Three", 80, 70);
            Player test_player_four = new Player("Player_Four", 50, 90);
            Die test_die = new CrookedDie(5);
            Dice test_dice = new Dice(test_die, test_die);
            List<Player> playerList = new List<Player>();
            playerList.Add(test_player_one);
            playerList.Add(test_player_two);
            playerList.Add(test_player_three);
            playerList.Add(test_player_four);
            Game test_game = new Game(playerList, test_dice);
            List<Game> gameSeries = new List<Game>();
            gameSeries.Add(test_game);
            Tournament testTournament = new Tournament(gameSeries);
            bool endOfTournament = testTournament.checkForTournamentEnd();
            Assert.AreEqual(endOfTournament, false);
        }

        [TestMethod]
        public void TestCheckForTournamentEndWithNoChips()
        {
            Player test_player_one = new Player("Player_One", 70, 40);
            Player test_player_two = new Player("Player_Two", 10, 0);
            Player test_player_three = new Player("Player_Three", 80, 70);
            Player test_player_four = new Player("Player_Four", 50, 90);
            Die test_die = new CrookedDie(5);
            Dice test_dice = new Dice(test_die, test_die);
            List<Player> playerList = new List<Player>();
            playerList.Add(test_player_one);
            playerList.Add(test_player_two);
            playerList.Add(test_player_three);
            playerList.Add(test_player_four);
            Game test_game = new Game(playerList, test_dice);
            List<Game> gameSeries = new List<Game>();
            gameSeries.Add(test_game);
            Tournament testTournament = new Tournament(gameSeries);
            bool endOfTournament = testTournament.checkForTournamentEnd();
            Assert.AreEqual(endOfTournament, true);
        }

        [TestMethod]
        public void TestCheckForTournamentEndWith150Chips()
        {
            Player test_player_one = new Player("Player_One", 70, 40);
            Player test_player_two = new Player("Player_Two", 10, 50);
            Player test_player_three = new Player("Player_Three", 80, 150);
            Player test_player_four = new Player("Player_Four", 50, 90);
            Die test_die = new CrookedDie(5);
            Dice test_dice = new Dice(test_die, test_die);
            List<Player> playerList = new List<Player>();
            playerList.Add(test_player_one);
            playerList.Add(test_player_two);
            playerList.Add(test_player_three);
            playerList.Add(test_player_four);
            Game test_game = new Game(playerList, test_dice);
            List<Game> gameSeries = new List<Game>();
            gameSeries.Add(test_game);
            Tournament testTournament = new Tournament(gameSeries);
            bool endOfTournament = testTournament.checkForTournamentEnd();
            Assert.AreEqual(endOfTournament, true);
        }

        [TestMethod]
        public void TestAddGameToSeries()
        {
            Player test_player_one = new Player("Player_One", 70, 40);
            Player test_player_two = new Player("Player_Two", 10, 50);
            Player test_player_three = new Player("Player_Three", 80, 70);
            Player test_player_four = new Player("Player_Four", 50, 90);
            Die test_die = new CrookedDie(5);
            Dice test_dice = new Dice(test_die, test_die);
            List<Player> playerList = new List<Player>();
            playerList.Add(test_player_one);
            playerList.Add(test_player_two);
            playerList.Add(test_player_three);
            playerList.Add(test_player_four);
            Game test_game = new Game(playerList, test_dice);
            List<Game> gameSeries = new List<Game>();
            gameSeries.Add(test_game);
            Tournament testTournament = new Tournament(gameSeries);
            int chipLeaderIndex = testTournament.getChipLeaderIndex();
            Assert.AreEqual(3, chipLeaderIndex);
            //create new game
            test_player_one = new Player("Player_One", 80, 80);
            test_player_two = new Player("Player_Two", 10, 40);
            test_player_three = new Player("Player_Three", 80, 30);
            test_player_four = new Player("Player_Four", 50, 50);
            playerList = new List<Player>();
            playerList.Add(test_player_one);
            playerList.Add(test_player_two);
            playerList.Add(test_player_three);
            playerList.Add(test_player_four);
            test_game = new Game(playerList, test_dice);
            testTournament.addGameToSeries(test_game);
            chipLeaderIndex = testTournament.getChipLeaderIndex();
            Assert.AreEqual(0, chipLeaderIndex);
        }
    }
}
