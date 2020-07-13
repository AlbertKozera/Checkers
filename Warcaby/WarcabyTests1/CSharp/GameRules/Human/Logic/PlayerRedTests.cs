using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warcaby.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warcaby.Forms;
using Warcaby.Service.Human;

namespace Warcaby.Service.Tests
{
    [TestClass()]
    public class PlayerRedTests
    {
        Common common = new Common();
        List<int> listOfPromotionalFieldsForRed = new List<int>(new int[] { 2, 4, 6, 8 });
        

        public void CompleteTheDictionaryTest()
        {
            TypeOfGame.gameBoard.Clear();
            // Loading white pawns
            for (int i = 2; i <= 24; i += 2)
            {
                TypeOfGame.gameBoard.Add(i, new Field(false, true, false, "white"));
                if (i == 8) i--;
                if (i == 15) i++;
            }
            // Loading empty fields
            for (int i = 25; i <= 38; i += 2)
            {
                TypeOfGame.gameBoard.Add(i, new Field(true, false, false, ""));
                if (i == 31) i++;
            }
            TypeOfGame.gameBoard.Add(47, new Field(true, false, false, ""));
            TypeOfGame.gameBoard.Add(40, new Field(false, true, false, "red"));
            // Loading red pawns
            for (int i = 41; i <= 63; i += 2)
            {
                TypeOfGame.gameBoard.Add(i, new Field(false, true, false, "red"));
                if (i == 45) i+=3;
                if (i == 56) i--;
            }

        }

        [TestMethod()]
        public void CheckerUpdateAfterMovingAPawnTest()
        {
            PictureBox fieldFrom = Extend.getFieldByName("field_47");
            PictureBox fieldTo = Extend.getFieldByName("field_38");
            int indexFrom = 47;
            int indexTo = 38;
        }

        [TestMethod()]
        public void CheckerUpdateAfterBeatingAPawnTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CheckForMoreBeatingTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CheckPromotionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void MovingAPawnThatHasNoBeating_ConditionTest()
        {
            //MainStage mainStage = new MainStage();
            UCNewGame uCNewGame = new UCNewGame();
            CompleteTheDictionaryTest();
            PlayerRed playerRed = new PlayerRed(uCNewGame.field_40, uCNewGame.field_47);
            Assert.AreEqual(false ,playerRed.MovingAPawnThatHasNoBeating_Condition());
        }

        [TestMethod()]
        public void MovingAPawnThatHasABeating_ConditionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CheckPromotion_ConditionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void FinishTheTurnTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RepeatTheTurnTest()
        {
            Assert.Fail();
        }
    }
}