using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Warcaby.Service.Context;
using System.Drawing;
using System.Windows.Forms;

namespace Warcaby.Forms.Tests
{
    [TestClass()]
    public class ExtendTests
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
            GameService.gameBoard[2] = Constant.DAME_RED;
            GameService.gameBoard[4] = Constant.DAME_RED;
        }
        [TestMethod()]
        public void IsNullOrEmptyListTest_Null()
        {
            //given
            List<int> listNull;
            //when
            listNull = null;
            //then
            Assert.AreEqual(true, Extend.IsNullOrEmpty(listNull));
        }

        [TestMethod()]
        public void IsNullOrEmptyListTest_Empty()
        {
            //given
            List<int> listEmpty = new List<int>();
            //when
            listEmpty.Clear();
            //then
            Assert.AreEqual(true, Extend.IsNullOrEmpty(listEmpty));
        }

        [TestMethod()]
        public void IsNullOrEmptyDictionaryTest_Null()
        {
            //given
            Dictionary<int, int> dictionaryNull;
            //when
            dictionaryNull = null;
            //then
            Assert.AreEqual(true, Extend.IsNullOrEmpty(dictionaryNull));
        }

        [TestMethod()]
        public void IsNullOrEmptyDictionaryTest_Empty()
        {
            //given
            Dictionary<int, int> dictionaryEmpty = new Dictionary<int, int>();
            //when
            dictionaryEmpty.Clear();
            //then
            Assert.AreEqual(true, Extend.IsNullOrEmpty(dictionaryEmpty));
        }

        [TestMethod()]
        public void IsEvenTestEven()
        {
            //given
            int number;
            //when
            number = 4;
            //then
            Assert.AreEqual(true, Extend.IsEven(number));
        }

        [TestMethod()]
        public void IsEvenTestOdd()
        {
            //given
            int number;
            //when
            number = 3;
            //then
            Assert.AreEqual(false, Extend.IsEven(number));
        }

        [TestMethod()]
        public void GetIndexFromFieldTest()
        {
            //given
            UCNewGame uCNewGame = new UCNewGame();
            PictureBox picture;
            //when
            picture = uCNewGame.field_38;
            //then
            Assert.AreEqual(38, Extend.GetIndexFromField(picture));
        }

        [TestMethod()]
        public void GetEnemyPlayerColorTest()
        {
            //given
            string expectedColor;
            string color;
            //when
            expectedColor = Constant.WHITE;
            color = Constant.RED;
            //then
            Assert.AreEqual(expectedColor, Extend.GetEnemyPlayerColor(color));
        }

        [TestMethod()]
        public void GetDameFieldDameWhiteTest()
        {
            //given
            Field field;
            string color;
            //when
            field = Constant.DAME_WHITE;
            color = Constant.WHITE;
            //then
            Assert.AreEqual(field, Extend.GetDameField(color));
        }

        [TestMethod()]
        public void GetDameFieldDameRedTest()
        {
            //given
            Field field;
            string color;
            //when
            field = Constant.DAME_RED;
            color = Constant.RED;
            //then
            Assert.AreEqual(field, Extend.GetDameField(color));
        }

        [TestMethod()]
        public void GetDameImageTest()
        {
            //given
            string color;
            //when
            color = Constant.WHITE;
            //then
            Assert.ReferenceEquals(new Bitmap(Properties.Resources.dame_white), Extend.GetDameImage(color));
        }

        [TestMethod()]
        public void GetNumberOfPawnsWhiteTest()
        {
            //given
            CompleteBoardTest();
            string color;
            int expectedResult;
            //when
            color = Constant.WHITE;
            expectedResult = 5;
            //then
            Assert.AreEqual(expectedResult, Extend.GetNumberOfPawns(color));
        }

        [TestMethod()]
        public void GetNumberOfPawnsRedTest()
        {
            //given
            CompleteBoardTest();
            string color;
            int expectedResult;
            //when
            color = Constant.RED;
            expectedResult = 4;
            //then
            Assert.AreEqual(expectedResult, Extend.GetNumberOfPawns(color));
        }

        [TestMethod()]
        public void GetNumberOfWhiteDamesTest()
        {
            //given
            CompleteBoardTest();
            string color;
            int expectedResult;
            //when
            color = Constant.WHITE;
            expectedResult = 1;
            //then
            Assert.AreEqual(expectedResult, Extend.GetNumberOfDames(color));
        }

        [TestMethod()]
        public void GetNumberOfRedDamesTest()
        {
            //given
            CompleteBoardTest();
            string color;
            int expectedResult;
            //when
            color = Constant.RED;
            expectedResult = 2;
            //then
            Assert.AreEqual(expectedResult, Extend.GetNumberOfDames(color));
        }
}