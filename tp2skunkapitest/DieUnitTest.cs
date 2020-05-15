using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using tp2skunkapi.Models;

namespace tp2skunkapitest
{
    [TestClass]
    public class DieUnitTest
    {
        [TestMethod]
        public void TestRoll()
        {
            Die testDie = new Die();
            Assert.IsTrue(testDie.getLastRoll() > 0 && testDie.getLastRoll() < 7);
        }
    }
}
