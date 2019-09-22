using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RUSSIANROULETTE_GAME;

namespace unitTest
{
    [TestClass]
    public class UnitTest1
    {
        GameLogic unittestobj = new GameLogic();
        [TestMethod]
        public void Testshootaway()
        {
            var nav = unittestobj.Shootaway(2);
            Assert.AreEqual(expected: 2, nav);

        }
        [TestMethod]
        public void TestShootAwaypositive()
        {
            var nav = unittestobj.Shootaway(0);
            Assert.AreEqual(expected: 2, nav);

        }


    }
}
