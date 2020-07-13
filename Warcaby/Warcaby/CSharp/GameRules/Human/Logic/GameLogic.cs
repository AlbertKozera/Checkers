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
        Pawn pawn = new Pawn();


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
                CheckerUpdateAfterMove();
                CheckIfThePawnHasReachedThePromotionField();
                FinishTheTurn(COLOR);
            }
        }

        public void MovingADameThatHasNoBeating()
        {
            if (Rule.TheDameWantsToMoveProperly(indexFrom, indexTo, COLOR))
            {
                CheckerUpdateAfterMove();
                FinishTheTurn(COLOR);
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
                        CheckerUpdateAfterBeat(forcedBeatingForPawnTuple.Item3);
                        CheckIfThePawnHasReachedThePromotionField();
                    }
                });
                CheckForMoreBeating();
                GameService.forcedBeatingForPawnsList.Clear();
            }
        }


        public void CheckerUpdateAfterMove()
        {
            UpdateFieldTo();
            UpdateFieldFrom();
        }

        public void CheckerUpdateAfterBeat(int indexThrough)
        {
            PictureBox fieldThrough = Extend.GetFieldByIndex(indexThrough);
            UpdateFieldThrough(fieldThrough, indexThrough);
            UpdateFieldTo();
            UpdateFieldFrom();       
        }

        public void CheckForMoreBeating()
        {
            GameService.forcedBeatingForPawnsList = pawn.GetDataAboutBeatings(COLOR);
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
                GameService.gameBoard[indexTo] = Extend.GetDameField(COLOR);
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
