using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using tp2skunkapi.Models;

namespace tp2skunkapitest
{
    [TestClass]
    public class DiceUnitTest
    {
        [TestMethod]
        public void TestRollAllValues()
        {
			Dice dice1 = new Dice();
			bool rollTwo = false;
			bool rollThree = false;
			bool rollFour = false;
			bool rollFive = false;
			bool rollSix = false;
			bool rollSeven = false;
			bool rollEight = false;
			bool rollNine = false;
			bool rollTen = false;
			bool rollEleven = false;
			bool rollTwelve = false;
			bool rollOverTwelve = false;
			bool rollUnderTwo = false;

			//roll dice 10000 times and check to see if all values between 2 and 12 are rolled at least once
			// and that no other values are rolled.
			for (int i = 0; i < 10000; i++)
			{
				dice1.roll();
				switch (dice1.getLastRoll())
				{
					case 2:
						rollTwo = true;
						break;
					case 3:
						rollThree = true;
						break;
					case 4:
						rollFour = true;
						break;
					case 5:
						rollFive = true;
						break;
					case 6:
						rollSix = true;
						break;
					case 7:
						rollSeven = true;
						break;
					case 8:
						rollEight = true;
						break;
					case 9:
						rollNine = true;
						break;
					case 10:
						rollTen = true;
						break;
					case 11:
						rollEleven = true;
						break;
					case 12:
						rollTwelve = true;
						break;
					default:
						if (dice1.getLastRoll() < 2)
							rollUnderTwo = true;
						else
							rollOverTwelve = true;
						break;
				}

			}
			//All values between 2 and 12 should be true (rolled at least once)
			 Assert.IsTrue(rollTwo);
			 Assert.IsTrue(rollThree);
			 Assert.IsTrue(rollFour);
			 Assert.IsTrue(rollFive);
			 Assert.IsTrue(rollSix);
			 Assert.IsTrue(rollSeven);
			 Assert.IsTrue(rollEight);
			 Assert.IsTrue(rollNine);
			 Assert.IsTrue(rollTen);
			 Assert.IsTrue(rollEleven);
			 Assert.IsTrue(rollTwelve);

			//All values less than 2 and greater than 12 should be false (never rolled)
			Assert.IsFalse(rollUnderTwo);
			Assert.IsFalse(rollOverTwelve);
		}

        [TestMethod]
        public void TestDieGetLastRoll()
        {
            Die testDie = new Die(6);
            Assert.IsTrue(testDie.getLastRoll() == 6);
        }

		[TestMethod]
		public void TestSetGetSkunkType()
		{
			Die die1 = new Die(1);
			Die die2 = new Die(2);
			Die die6 = new Die(6);
			Dice testDice = new Dice(die1, die1);
			testDice.setSkunkType(die1, die1);
			SkunkType currentSkunkType = testDice.getSkunkType();
			Assert.IsTrue(currentSkunkType == SkunkType.DOUBLE);
			testDice.setSkunkType(die1, die2);
			currentSkunkType = testDice.getSkunkType();
			Assert.IsTrue(currentSkunkType == SkunkType.SKUNKDUECE);
			testDice.setSkunkType(die1, die6);
			currentSkunkType = testDice.getSkunkType();
			Assert.IsTrue(currentSkunkType == SkunkType.SINGLE);
		}
	}
}
