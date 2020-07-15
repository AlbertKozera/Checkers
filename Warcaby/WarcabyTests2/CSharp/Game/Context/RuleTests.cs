using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Warcaby.Service.Context;
using Warcaby.Forms;

namespace Warcaby.CSharp.Game.Context.Tests
{
    [TestClass()]
    public class RuleTests
    {
        Pawn pawn = new Pawn();
        Dame dame = new Dame();
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
        public void ThePawnWasBeatingAccordingToTheRulesTest()
        {
            //given
            CompleteBoardTest();
            int indexFrom = 40;
            int indexTo = 22;
            //when 
            pawn.anyBeatings.Add(Tuple.Create(40, 31, 22));
            GameService.forcedBeatingForPawnsList = pawn.GetDataAboutBeatings("red");
            //then
            Assert.AreEqual(true, Rule.ThePawnWasBeatingAccordingToTheRules(indexFrom, indexTo));
        }

        [TestMethod()]
        public void TheDameWasBeatingAccordingToTheRulesTest()
        {
            //given
            CompleteBoardTest();
            int indexFrom = 34;
            int indexTo = 52;
            int indexThrough = 43;
            string color = "white";
            List<int> indexToList = new List<int>();
            indexToList.Add(indexThrough);
            //when
            dame.GetIndexThrough(color, indexFrom, indexTo);
            dame.anyBeatings.Add(Tuple.Create(indexFrom, indexThrough), indexToList);
            GameService.forcedBeatingForDamesList = dame.GetDataAboutBeatings(color);
            //then
            Assert.AreEqual(true, Rule.TheDameWasBeatingAccordingToTheRules(indexFrom, indexTo, color));
        }

        [TestMethod()]
        public void ThePawnHasABeatOnSpecificDiagonalTest()
        {
            //given
            // red from index 40 to 22, enemy white on index 31
            CompleteBoardTest();
            //when
            string myColor = "red";
            int index = 40;
            //then
            Assert.AreEqual(true, Rule.ThePawnHasABeatOnSpecificDiagonal(myColor, index, Constant.TOP_LEFT));
        }

        [TestMethod()]
        public void TheDameHasABeatOnSpecificDiagonalTest()
        {
            //given
            CompleteBoardTest();
            //when
            int index = 34;
            string myColor = "white";
            //then
            Assert.AreEqual(true, Rule.TheDameHasABeatOnSpecificDiagonal(myColor, index, Constant.DOWN_RIGHT));
        }

        [TestMethod()]
        public void ThePawnStoodInThePromotionFieldTest()
        {
            //given
            CompleteBoardTest();
            //when
            int index = 63;
            string color = "white";
            //then
            Assert.AreEqual(true, Rule.ThePawnStoodInThePromotionField(index, color));
        }
    }
}