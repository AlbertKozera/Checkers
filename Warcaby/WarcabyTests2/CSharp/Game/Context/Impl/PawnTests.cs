using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Warcaby.Service.Context;
using Warcaby.Forms;
using Warcaby.CSharp.Config;
using Warcaby.CSharp.Game.Context.Impl;

namespace Warcaby.CSharp.Game.Context.Tests
{
    [TestClass()]
    public class PawnTests
    {
        Pawn pawn = new Pawn();
        public void CompleteBoardTest()
        {
            GameService.gameBoard.Clear();
            for (int i = 2; i <= 63; i += 2)
            {
                GameService.gameBoard.Add(i, Constant.EMPTY_FIELD);
                if (i == 8) i--;
                if (i == 15) i++;
                if (i == 24) i--;
                if (i == 31) i++;
                if (i == 40) i--;
                if (i == 47) i++;
                if (i == 56) i--;
            }
            GameService.gameBoard[18] = Constant.PAWN_WHITE;
            GameService.gameBoard[20] = Constant.PAWN_WHITE;
            GameService.gameBoard[31] = Constant.PAWN_WHITE;
            GameService.gameBoard[24] = Constant.PAWN_WHITE;
            GameService.gameBoard[40] = Constant.PAWN_RED;
            GameService.gameBoard[43] = Constant.PAWN_RED;
            GameService.gameBoard[45] = Constant.PAWN_RED;
            GameService.gameBoard[47] = Constant.PAWN_RED;
            GameService.gameBoard[34] = Constant.DAME_WHITE;
            GameService.gameBoard[63] = Constant.PAWN_WHITE;
        }
        [TestMethod()]
        public void GetDataAboutBeatingsTest()
        {
            //given
            List<Tuple<int, int, int>> expectedResultList = new List<Tuple<int, int, int>>();
            CompleteBoardTest();
            //when
            expectedResultList.Add(Tuple.Create(40, 31, 22));
            expectedResultList.Add(Tuple.Create(43, 34, 25));
            //then
            CollectionAssert.AreEqual(expectedResultList, pawn.GetDataAboutBeatings("red"));
        }

        [TestMethod()]
        public void SearchDiagonalForBeatingsTest()
        {
            //given
            List<Tuple<int, int, int>> expectedResultList = new List<Tuple<int, int, int>>();
            CompleteBoardTest();
            //when
            expectedResultList.Add(Tuple.Create(40, 31, 22));
            expectedResultList.Add(Tuple.Create(43, 34, 25));
            //then
            pawn.SearchDiagonalForBeatings("red", Constant.TOP_LEFT);
            CollectionAssert.AreEqual(expectedResultList, pawn.anyBeatings);
        }

        [TestMethod()]
        public void GetIndexThroughTest()
        {
            //given
            CompleteBoardTest();
            //when
            int indexFrom = 40;
            int indexTo = 22;
            //then
            Assert.AreEqual(31, pawn.GetIndexThrough(indexFrom, indexTo));
        }
    }
}