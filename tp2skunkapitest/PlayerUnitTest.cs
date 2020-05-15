using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using tp2skunkapi.Models;

namespace tp2skunkapitest
{
    [TestClass]
    public class PlayerUnitTest
    {
        [TestMethod]
        public void TestDoubleSkunk()
        {
            //Expect to see score set to 0, regardless of value, and chip count to decrease by 4.

            Player testPlayerOne = new Player("TestPlayer1", 50, 50);
            testPlayerOne.doubleSkunk();
            Assert.AreEqual(testPlayerOne.getScore(), 0);
            Assert.AreEqual(testPlayerOne.getChipCount(), 46);

            Player testPlayerTwo = new Player("TestPlayer2", 101, 0);
            testPlayerTwo.doubleSkunk();
            Assert.AreEqual(testPlayerTwo.getScore(), 0);
            Assert.AreEqual(testPlayerTwo.getChipCount(), -4); //Probably shouldn't allow for negative chip count?

            Player testPlayerThree = new Player("TestPlayer3", 0, 101);
            testPlayerThree.doubleSkunk();
            Assert.AreEqual(testPlayerThree.getScore(), 0);
            Assert.AreEqual(testPlayerThree.getChipCount(), 97);
        }

        [TestMethod]
        public void TestSingleSkunk()
        {
            //Expect to see chip count decrease by 1 chip and no change in score.

            Player testPlayerOne = new Player("TestPlayer1", 50, 50);
            testPlayerOne.singleSkunk();
            Assert.AreEqual(testPlayerOne.getScore(), 50);
            Assert.AreEqual(testPlayerOne.getChipCount(), 49);

            Player testPlayerTwo = new Player("TestPlayer2", 101, 0);
            testPlayerTwo.singleSkunk();
            Assert.AreEqual(testPlayerTwo.getScore(), 101);
            Assert.AreEqual(testPlayerTwo.getChipCount(), -1); //Probably shouldn't allow for negative chip count?

            Player testPlayerThree = new Player("TestPlayer3", 0, 101);
            testPlayerThree.singleSkunk();
            Assert.AreEqual(testPlayerThree.getScore(), 0); //Probably shouldn't allow for a negative score?
            Assert.AreEqual(testPlayerThree.getChipCount(), 100);
        }

        [TestMethod]
        public void TestSkunkDeuce()
        {
            //Expect to see chip count decrease by 2 chip and no change in score.
            //Also tests "getChipCount() and getScore() methods.
            Player testPlayerOne = new Player("TestPlayer1", 50, 50);
            testPlayerOne.skunkDeuce();
            Assert.AreEqual(testPlayerOne.getScore(), 50);
            Assert.AreEqual(testPlayerOne.getChipCount(), 48);

            Player testPlayerTwo = new Player("TestPlayer2", 101, 0);
            testPlayerTwo.skunkDeuce();
            Assert.AreEqual(testPlayerTwo.getScore(), 101);
            Assert.AreEqual(testPlayerTwo.getChipCount(), -2); //Probably shouldn't allow for negative chip count?

            Player testPlayerThree = new Player("TestPlayer3", 0, 101);
            testPlayerThree.skunkDeuce();
            Assert.AreEqual(testPlayerThree.getScore(), 0); //Probably shouldn't allow for a negative score?
            Assert.AreEqual(testPlayerThree.getChipCount(), 99);
        }

        [TestMethod]
        public void TestPlayerName()
        {
            //Test to get player name		
            Player testPlayerOne = new Player("TestPlayer1", 50, 50);
            Assert.AreEqual(testPlayerOne.getPlayerName(), "TestPlayer1");

            testPlayerOne.setPlayerName("TestPlayer1_Change");
            Assert.AreEqual(testPlayerOne.getPlayerName(), "TestPlayer1_Change");

        }

        [TestMethod]
        public void TestScore()
        {
            //Test score modification
            Player testPlayer = new Player();
            testPlayer.setScore(50);
            Assert.AreEqual(testPlayer.getScore(), 50);

            testPlayer.addScore(10);
            Assert.AreEqual(testPlayer.getScore(), 60);
        }

        [TestMethod]
        public void TestChipCount()
        {
            //Test chip count modification
            Player testPlayer = new Player();
            Assert.AreEqual(testPlayer.getChipCount(), 100);

            testPlayer.setChipCount(50);
            Assert.AreEqual(testPlayer.getChipCount(), 50);
        }
    }
}
