﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kontur
{
    [TestClass]
    public class UnitTestImmutableGame: UnitTestBaseGame
    {
        [TestMethod]
        override public void TestLocation()
        {
            ImmutableGame game = new ImmutableGame(1, 2, 3, 0);

            Assert.AreEqual(game[0, 0], 1);
            Assert.AreEqual(game[1, 1], 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        override public void TestBadShift()
        {
            ImmutableGame game = new ImmutableGame(0, 1, 2, 3);

            game = (ImmutableGame)game.Shift(1);
            game = (ImmutableGame)game.Shift(2);

            Assert.Fail();
        }

        [TestMethod]
        override public void TestShift()
        {
            ImmutableGame game = new ImmutableGame(0, 1, 2, 3);

            game = (ImmutableGame)game.Shift(1);

            Assert.AreEqual(1, game[0, 0]);
        }

        [TestMethod]
        override public void Test3by3()
        {
            ImmutableGame game = new ImmutableGame(0, 1, 2, 3, 4, 5, 6, 7, 8);

            game = (ImmutableGame)game.Shift(1);
            game = (ImmutableGame)game.Shift(4);
            game = (ImmutableGame)game.Shift(5);
            ImmutableGame newGame = (ImmutableGame)game.Shift(8);
            game = (ImmutableGame)game.Shift(8);

            Assert.AreEqual(0, game[2, 2]);
            Assert.AreEqual(0, newGame[2, 2]);            
        }

        [TestMethod]
        override public void Test4by4()
        {
            ImmutableGame game = new ImmutableGame(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
           
            game = (ImmutableGame)game.Shift(4);
            game = (ImmutableGame)game.Shift(8);
            game = (ImmutableGame)game.Shift(9);
            game = (ImmutableGame)game.Shift(10);
            game = (ImmutableGame)game.Shift(14);
            game = (ImmutableGame)game.Shift(13);
            game = (ImmutableGame)game.Shift(13);
            game = (ImmutableGame)game.Shift(15);

            Assert.AreEqual(0, game[3, 3]);
        }

    }
}
