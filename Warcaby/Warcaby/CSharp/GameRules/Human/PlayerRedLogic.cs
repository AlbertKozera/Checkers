using System;
using System.Drawing;
using System.Windows.Forms;
using Warcaby.Forms;
using Warcaby.Service.Human;


namespace Warcaby.Service
{
    public class PlayerRedLogic : IPlayerLogic
    {
        CommonLogic commonLogic = new CommonLogic();
        PictureBox fieldFrom;
        PictureBox fieldTo;
        int indexFrom;
        int indexTo;
        
        public PlayerRedLogic(PictureBox fieldFrom, PictureBox fieldTo)
        {
            this.fieldFrom = fieldFrom;
            this.fieldTo = fieldTo;
            indexFrom = Int16.Parse(fieldFrom.Tag.ToString());
            indexTo = Int16.Parse(fieldTo.Tag.ToString());
        }

        public void CheckerUpdateAfterMovingAPawn()
        {
            fieldFrom.Image = new Bitmap(Properties.Resources.empty_field);
            TypeOfGame.gameBoard[indexFrom] = Constant.EMPTY_FIELD;
            fieldTo.Image = new Bitmap(Properties.Resources.pawn_red);
            TypeOfGame.gameBoard[indexTo] = Constant.PAWN_RED;
            TypeOfGame.round = true;
        }

        public void CheckerUpdateAfterBeatingAPawn(int indexThrough)
        {
            fieldFrom.Image = new Bitmap(Properties.Resources.empty_field);
            TypeOfGame.gameBoard[indexFrom] = Constant.EMPTY_FIELD;
            PictureBox fieldThrough = (PictureBox) Application.OpenForms["MainStage"].Controls.Find(Constant.FIELD + indexThrough, true)[0];
            fieldThrough.Image = new Bitmap(Properties.Resources.empty_field);
            TypeOfGame.gameBoard[indexThrough] = Constant.EMPTY_FIELD;
            fieldTo.Image = new Bitmap(Properties.Resources.pawn_red);
            TypeOfGame.gameBoard[indexTo] = Constant.PAWN_RED;
        }

        public void CheckForMoreBeating()
        {
            TypeOfGame.forcedBeatingForPawnList = commonLogic.DoesPawnHaveAnyBeating(TypeOfGame.gameBoard, Constant.RED);
            if (Extend.IsNullOrEmpty(TypeOfGame.forcedBeatingForPawnList))
                TypeOfGame.round = true;
            else
                TypeOfGame.round = false;
        }

        public Boolean MovingAPawnThatHasNoBeating_Condition()
        {
            return (TypeOfGame.gameBoard[indexFrom].color.Equals(Constant.RED)) && (Extend.IsNullOrEmpty(TypeOfGame.forcedBeatingForPawnList)) && (indexTo == indexFrom - 7 || indexTo == indexFrom - 9) && (TypeOfGame.gameBoard[indexTo].isEmptyField);
        }

        public Boolean MovingAPawnThatHasABeating_Condition()
        {
            return (TypeOfGame.gameBoard[indexFrom].color.Equals(Constant.RED)) && (!Extend.IsNullOrEmpty(TypeOfGame.forcedBeatingForPawnList)) && (indexTo == indexFrom - 14 || indexTo == indexFrom - 18 || indexTo == indexFrom + 14 || indexTo == indexFrom + 18) && (TypeOfGame.gameBoard[indexTo].isEmptyField);
        }
    }
}
