using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Warcaby.Service.Context;
using Warcaby.Forms;
using Warcaby.CSharp.Config;
using Warcaby.CSharp.Game.Context.Impl;

namespace Warcaby.CSharp.Game.Context.Tests
{
    [TestClass()]
    public class DameTests
    {
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
            Dictionary<Tuple<int, int>, List<int>> expectedResultDictionary = new Dictionary<Tuple<int, int>, List<int>>();
            List<int> indexToList = new List<int>();
            Dame dame = new Dame();
            CompleteBoardTest();
            //when
            int indexFrom = 34;
            int indexThrough = 43;
            indexToList.Add(52);
            indexToList.Add(61);
            expectedResultDictionary.Add(Tuple.Create(indexFrom, indexThrough), indexToList);
            //then
            CollectionAssert.AreEqual(expectedResultDictionary.Keys, dame.GetDataAboutBeatings("white").Keys);
            Assert.AreEqual(expectedResultDictionary.Count(), dame.GetDataAboutBeatings("white").Count());
        }

        [TestMethod()]
        public void GetAllowedMovesTest()
        {
            //given
            List<int> expectedResultList = new List<int>();
            Dame dame = new Dame();
            CompleteBoardTest();
            //when
            int index = 34;
            expectedResultList.Add(25);
            expectedResultList.Add(27);
            expectedResultList.Add(41);
            //then
            Assert.AreEqual(expectedResultList.Count(), dame.GetAllowedMoves(index).Count());
        }

        [TestMethod()]
        public void SearchDiagonalForBeatingsTest()
        {
            //given
            Dictionary<Tuple<int, int>, List<int>> expectedResultDictionary = new Dictionary<Tuple<int, int>, List<int>>();
            List<int> indexToList = new List<int>();
            Dame dame = new Dame();
            CompleteBoardTest();
            //when
            int indexFrom = 34;
            int indexThrough = 43;
            indexToList.Add(52);
            indexToList.Add(61);
            expectedResultDictionary.Add(Tuple.Create(indexFrom, indexThrough), indexToList);
            //then
            dame.SearchDiagonalForBeatings("white", Constant.DOWN_RIGHT);
            Assert.AreEqual(expectedResultDictionary.Count(), dame.anyBeatings.Count());
        }

        [TestMethod()]
        public void SearchDiagonalForEmptyFieldsTest()
        {
            //given
            List<int> expectedResult = new List<int>();
            Dame dame = new Dame();
            CompleteBoardTest();
            //when
            int indexFrom = 34;
            expectedResult.Add(25);
            //then
            CollectionAssert.AreEqual(expectedResult, dame.SearchDiagonalForEmptyFields(indexFrom, Constant.TOP_LEFT));
        }

        [TestMethod()]
        public void GetIndexThroughTest()
        {
            //given
            Dame dame = new Dame();
            CompleteBoardTest();
            //when
            int indexFrom = 34;
            int indexTo = 52;
            string myColor = "white";
            //then
            Assert.AreEqual(43, dame.GetIndexThrough(myColor, indexFrom, indexTo));
        }

        [TestMethod()]
        public void GetIndexThroughByDiagonalTest()
        {
            //given
            Dame dame = new Dame();
            CompleteBoardTest();
            //when
            int indexFrom = 34;
            string myColor = "white";
            //then
            Assert.AreEqual(43, dame.GetIndexThroughByDiagonal(myColor, indexFrom, Constant.DOWN_RIGHT));
        }
    }
}