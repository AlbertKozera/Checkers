using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warcaby.Service.Context;
using Warcaby.Forms;
using Warcaby.CSharp.Forms;
using Warcaby.CSharp.Game.Context.Impl;
using Warcaby.CSharp.Config;
using System.Reflection.Emit;

namespace Warcaby.CSharp.Game.Context.Tests
{
    [TestClass()]
    public class GameLogicTests
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
            GameService.gameBoard[9] = Constant.PAWN_RED;
            GameService.gameBoard[34] = Constant.DAME_WHITE;
        }

        [TestMethod()]
        public void UpdateFieldFromTest()
        {
            //given
            UCNewGame uCNewGame = new UCNewGame(1);
            CompleteBoardTest();
            //when
            GameLogic gameLogic = new GameLogic(uCNewGame.field_18, uCNewGame.field_25, 18, 25, "white");
            //then
            gameLogic.UpdateFieldFrom();
            Assert.AreEqual(Constant.EMPTY_FIELD, GameService.gameBoard[18]);
        }

        [TestMethod()]
        public void UpdateFieldToTest()
        {
            //given
            UCNewGame uCNewGame = new UCNewGame(1);
            CompleteBoardTest();
            //when
            GameLogic gameLogic = new GameLogic(uCNewGame.field_45, uCNewGame.field_36, 45, 36, "red");
            //then
            gameLogic.UpdateFieldTo();
            Assert.AreEqual(Constant.PAWN_RED, GameService.gameBoard[36]);
        }
    }
}