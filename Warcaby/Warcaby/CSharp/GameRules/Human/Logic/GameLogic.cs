using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Warcaby.CSharp.GameRules.Human.Logic;
using Warcaby.Forms;
using Warcaby.Service.Human;


namespace Warcaby.Service
{
    public class GameLogic
    {
        PictureBox fieldFrom;
        PictureBox fieldTo;
        int indexFrom;
        int indexTo;
        string COLOR;
        Common common = new Common();


        public GameLogic(PictureBox fieldFrom, PictureBox fieldTo, int indexFrom, int indexTo, string COLOR)
        {
            this.fieldFrom = fieldFrom;
            this.fieldTo = fieldTo;
            this.indexFrom = indexFrom;
            this.indexTo = indexTo;
            this.COLOR = COLOR;
        }

        public void MovingAPawnThatHasNoBeating()
        {
            if (Rule.ThePawnWantsToMoveProperly(indexFrom, indexTo, COLOR))
            {
                CheckerUpdateAfterMovingAPawn();
            }
        }

        public void MovingAPawnThatHasABeating()
        {
            if (Rule.PawnWantToExecuteBeatProperly(indexFrom, indexTo, COLOR))
            {
                GameService.forcedBeatingForPawnsList.ForEach(delegate (Tuple<int, int, int> forcedBeatingForPawnTuple)
                {
                    if (forcedBeatingForPawnTuple.Item2 == indexTo)
                    {
                        CheckerUpdateAfterBeatingAPawn(forcedBeatingForPawnTuple.Item3);
                    }
                });
                CheckForMoreBeating();
                GameService.forcedBeatingForPawnsList.Clear();
            }
        }

        public void CheckerUpdateAfterMovingAPawn()
        {
            UpdateFieldTo();
            UpdateFieldFrom();
            CheckIfThePawnHasReachedThePromotionField();
            FinishTheTurn(COLOR);
        }

        public void CheckerUpdateAfterBeatingAPawn(int indexThrough)
        {
            PictureBox fieldThrough = Extend.GetFieldByIndex(indexThrough);
            UpdateFieldThrough(fieldThrough, indexThrough);
            UpdateFieldTo();
            UpdateFieldFrom();
            CheckIfThePawnHasReachedThePromotionField();
        }

        public void CheckForMoreBeating()
        {
            GameService.forcedBeatingForPawnsList = common.GetDataAboutBeatingsForPawns(GameService.gameBoard, COLOR);
            if (Extend.IsNullOrEmpty(GameService.forcedBeatingForPawnsList))
                FinishTheTurn(COLOR);
            else
                RepeatTheTurn(COLOR);
        }

        public void CheckIfThePawnHasReachedThePromotionField()
        {
            if (Rule.ThePawnStoodInThePromotionField(indexTo, COLOR))
            {
                fieldTo.Image = Extend.GetDameImage(COLOR);
                GameService.gameBoard[indexTo] = Constant.DAME_RED;
            }
        }

        public void UpdateFieldFrom()
        {
            fieldFrom.Image = new Bitmap(Properties.Resources.empty_field);
            GameService.gameBoard[indexFrom] = Constant.EMPTY_FIELD;
        }

        public void UpdateFieldThrough(PictureBox fieldThrough, int indexThrough)
        {
            fieldThrough.Image = new Bitmap(Properties.Resources.empty_field);
            GameService.gameBoard[indexThrough] = Constant.EMPTY_FIELD;
        }

        public void UpdateFieldTo()
        {
            fieldTo.Image = fieldFrom.Image;
            GameService.gameBoard[indexTo] = GameService.gameBoard[indexFrom];
        }

        public void FinishTheTurn(string color)
        {
            if (color.Equals(Constant.WHITE))
                GameService.whiteTurn = false;
            else
                GameService.whiteTurn = true;
        }

        public void RepeatTheTurn(string color)
        {
            if (color.Equals(Constant.WHITE))
                GameService.whiteTurn = true;
            else
                GameService.whiteTurn = false;
        }
    }
}
