using System;
using System.Drawing;
using System.Windows.Forms;
using Warcaby.Forms;
using Warcaby.Service.Human;


namespace Warcaby.Service
{
    public class PlayerWhite : IPlayerLogic
    {
        CommonLogic checkerLogic = new CommonLogic();
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
                ServiceTmp.round = false;
            }
        }

        public void MovingAPawnThatHasABeating()
        {
            if (MovingAPawnThatHasABeating_Condition())
            {
                ServiceTmp.forcedBeatingForPawnList.ForEach(delegate (Tuple<int, int, int> forcedBeatingForPawnTuple)
                {
                    if (forcedBeatingForPawnTuple.Item2 == indexTo)
                    {
                        CheckerUpdateAfterBeatingAPawn(forcedBeatingForPawnTuple.Item3);
                    }
                });
                CheckForMoreBeating();
                ServiceTmp.forcedBeatingForPawnList.Clear();
            }
        }

        public void CheckerUpdateAfterMovingAPawn()
        {
            fieldFrom.Image = new Bitmap(Properties.Resources.empty_field);
            ServiceTmp.gameBoard[indexFrom] = Constant.EMPTY_FIELD;
            fieldTo.Image = new Bitmap(Properties.Resources.pawn_white);
            ServiceTmp.gameBoard[indexTo] = Constant.PAWN_WHITE;
        }

        public void CheckerUpdateAfterBeatingAPawn(int indexThrough)
        {
            fieldFrom.Image = new Bitmap(Properties.Resources.empty_field);
            ServiceTmp.gameBoard[indexFrom] = Constant.EMPTY_FIELD;
            PictureBox fieldThrough = (PictureBox) Application.OpenForms["MainStage"].Controls.Find(Constant.FIELD + indexThrough, true)[0];
            fieldThrough.Image = new Bitmap(Properties.Resources.empty_field);
            ServiceTmp.gameBoard[indexThrough] = Constant.EMPTY_FIELD;
            fieldTo.Image = new Bitmap(Properties.Resources.pawn_white);
            ServiceTmp.gameBoard[indexTo] = Constant.PAWN_WHITE;
        }

        public void CheckForMoreBeating()
        {
            ServiceTmp.forcedBeatingForPawnList = checkerLogic.DoesPawnHaveAnyBeating(ServiceTmp.gameBoard, Constant.WHITE);
            if (Extend.IsNullOrEmpty(ServiceTmp.forcedBeatingForPawnList))
                ServiceTmp.round = false;
            else
                ServiceTmp.round = true;
        }

        public Boolean MovingAPawnThatHasNoBeating_Condition()
        {
            return (Extend.IsNullOrEmpty(ServiceTmp.forcedBeatingForPawnList)) && (indexTo == indexFrom + 7 || indexTo == indexFrom + 9) && (ServiceTmp.gameBoard[indexTo].isEmptyField);
        }

        public Boolean MovingAPawnThatHasABeating_Condition()
        {
            return (!Extend.IsNullOrEmpty(ServiceTmp.forcedBeatingForPawnList)) && (indexTo == indexFrom - 14 || indexTo == indexFrom - 18 || indexTo == indexFrom + 14 || indexTo == indexFrom + 18) && (ServiceTmp.gameBoard[indexTo].isEmptyField);
        }
    }
}
