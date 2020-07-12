using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Warcaby.Forms;
using Warcaby.Service.Human;


namespace Warcaby.Service
{
    public class PlayerRed : IPlayer
    {
        Common common = new Common();
        PictureBox fieldFrom;
        PictureBox fieldTo;
        int indexFrom;
        int indexTo;
        List<int> listOfPromotionalFieldsForRed = new List<int>(new int[] { 2, 4, 6, 8 });


        public PlayerRed(PictureBox fieldFrom, PictureBox fieldTo)
        {
            this.fieldFrom = fieldFrom;
            this.fieldTo = fieldTo;
            indexFrom = Int16.Parse(fieldFrom.Tag.ToString());
            indexTo = Int16.Parse(fieldTo.Tag.ToString());
        }

        public void CheckerUpdateAfterMovingAPawn()
        {
            common.UpdateFieldTo(fieldTo, fieldFrom, indexTo, indexFrom);
            common.UpdateFieldFrom(fieldFrom, indexFrom);
            CheckPromotion();
            FinishTheTurn();
        }

        public void CheckerUpdateAfterBeatingAPawn(int indexThrough)
        {
            PictureBox fieldThrough = Extend.getFieldByName(Constant.FIELD + indexThrough);
            common.UpdateFieldThrough(fieldThrough, indexThrough);
            common.UpdateFieldTo(fieldTo, fieldFrom, indexTo, indexFrom);
            common.UpdateFieldFrom(fieldFrom, indexFrom);
            CheckPromotion();
        }

        public void CheckForMoreBeating()
        {
            TypeOfGame.forcedBeatingForPawnList = common.DoesPawnHaveAnyBeating(TypeOfGame.gameBoard, Constant.RED);
            if (Extend.IsNullOrEmpty(TypeOfGame.forcedBeatingForPawnList))
                FinishTheTurn();
            else
                RepeatTheTurn();
        }

        public void CheckPromotion()
        {
            if (CheckPromotion_Condition())
            {
                fieldTo.Image = new Bitmap(Properties.Resources.dame_red);
                TypeOfGame.gameBoard[indexTo] = Constant.DAME_RED;
            }
        }

        public Boolean MovingAPawnThatHasNoBeating_Condition()
        {
            return (TypeOfGame.gameBoard[indexFrom].color.Equals(Constant.RED)) && (Extend.IsNullOrEmpty(TypeOfGame.forcedBeatingForPawnList)) && (indexTo == indexFrom - 7 || indexTo == indexFrom - 9) && (TypeOfGame.gameBoard[indexTo].isEmptyField);
        }

        public Boolean MovingAPawnThatHasABeating_Condition()
        {
            return (TypeOfGame.gameBoard[indexFrom].color.Equals(Constant.RED)) && (!Extend.IsNullOrEmpty(TypeOfGame.forcedBeatingForPawnList)) && (indexTo == indexFrom - 14 || indexTo == indexFrom - 18 || indexTo == indexFrom + 14 || indexTo == indexFrom + 18) && (TypeOfGame.gameBoard[indexTo].isEmptyField);
        }

        public Boolean CheckPromotion_Condition()
        {
            return listOfPromotionalFieldsForRed.Contains(indexTo);
        }

        public void FinishTheTurn()
        {
            TypeOfGame.whiteTurn = true;
        }

        public void RepeatTheTurn()
        {
            TypeOfGame.whiteTurn = false;
        }
    }
}
