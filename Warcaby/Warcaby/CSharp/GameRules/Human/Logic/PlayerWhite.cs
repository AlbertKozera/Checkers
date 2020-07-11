using System;
using System.Drawing;
using System.Windows.Forms;
using Warcaby.Forms;
using Warcaby.Service.Human;


namespace Warcaby.Service
{
    public class PlayerWhite : IPlayer
    {
        Common common = new Common();
        PictureBox fieldFrom;
        PictureBox fieldTo;
        int indexFrom;
        int indexTo;


        public PlayerWhite(PictureBox fieldFrom, PictureBox fieldTo)
        {
            this.fieldFrom = fieldFrom;
            this.fieldTo = fieldTo;
            indexFrom = Int16.Parse(fieldFrom.Tag.ToString());
            indexTo = Int16.Parse(fieldTo.Tag.ToString());
        }

        public void MovingAPawnThatHasNoBeating()
        {
            if (MovingAPawnThatHasNoBeating_Condition())
            {
                CheckerUpdateAfterMovingAPawn();
            }
        }

        public void MovingAPawnThatHasABeating()
        {
            if (MovingAPawnThatHasABeating_Condition())
            {
                TypeOfGame.forcedBeatingForPawnList.ForEach(delegate (Tuple<int, int, int> forcedBeatingForPawnTuple)
                {
                    if (forcedBeatingForPawnTuple.Item2 == indexTo)
                    {
                        CheckerUpdateAfterBeatingAPawn(forcedBeatingForPawnTuple.Item3);
                    }
                });
                CheckForMoreBeating();
                TypeOfGame.forcedBeatingForPawnList.Clear();
            }
        }

        public void CheckerUpdateAfterMovingAPawn()
        {
            fieldFrom.Image = new Bitmap(Properties.Resources.empty_field);
            TypeOfGame.gameBoard[indexFrom] = Constant.EMPTY_FIELD;
            fieldTo.Image = new Bitmap(Properties.Resources.pawn_white);
            TypeOfGame.gameBoard[indexTo] = Constant.PAWN_WHITE;
            TypeOfGame.round = false;
        }

        public void CheckerUpdateAfterBeatingAPawn(int indexThrough)
        {
            fieldFrom.Image = new Bitmap(Properties.Resources.empty_field);
            TypeOfGame.gameBoard[indexFrom] = Constant.EMPTY_FIELD;
            PictureBox fieldThrough = (PictureBox) Application.OpenForms["MainStage"].Controls.Find(Constant.FIELD + indexThrough, true)[0];
            fieldThrough.Image = new Bitmap(Properties.Resources.empty_field);
            TypeOfGame.gameBoard[indexThrough] = Constant.EMPTY_FIELD;
            fieldTo.Image = new Bitmap(Properties.Resources.pawn_white);
            TypeOfGame.gameBoard[indexTo] = Constant.PAWN_WHITE;
        }

        public void CheckForMoreBeating()
        {
            TypeOfGame.forcedBeatingForPawnList = common.DoesPawnHaveAnyBeating(TypeOfGame.gameBoard, Constant.WHITE);
            if (Extend.IsNullOrEmpty(TypeOfGame.forcedBeatingForPawnList))
                TypeOfGame.round = false;
            else
                TypeOfGame.round = true;
        }

        public Boolean MovingAPawnThatHasNoBeating_Condition()
        {
            return (TypeOfGame.gameBoard[indexFrom].color.Equals(Constant.WHITE)) && (Extend.IsNullOrEmpty(TypeOfGame.forcedBeatingForPawnList)) && (indexTo == indexFrom + 7 || indexTo == indexFrom + 9) && (TypeOfGame.gameBoard[indexTo].isEmptyField);
        }

        public Boolean MovingAPawnThatHasABeating_Condition()
        {
            return (TypeOfGame.gameBoard[indexFrom].color.Equals(Constant.WHITE)) && (!Extend.IsNullOrEmpty(TypeOfGame.forcedBeatingForPawnList)) && (indexTo == indexFrom - 14 || indexTo == indexFrom - 18 || indexTo == indexFrom + 14 || indexTo == indexFrom + 18) && (TypeOfGame.gameBoard[indexTo].isEmptyField);
        }
    }
}
