using System;
using System.Drawing;
using System.Windows.Forms;
using Warcaby.Forms;
using Warcaby.Service.Human;


namespace Warcaby.CSharp.GameRules.Human.Logic
{
    public class GameLogic
    {
        PictureBox fieldFrom;
        PictureBox fieldTo;
        int indexFrom;
        public static int indexThrough;
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
            if (Rule.ThePawnWantToExecuteBeatProperly(indexFrom, indexTo, COLOR))
            {
                CheckerUpdateAfterBeat();
                CheckForMoreBeating();
            }
        }

        public void MovingADameThatHasABeating()
        {
            if (Rule.TheDameWantToExecuteBeatProperly(indexFrom, indexTo, COLOR))
            {
                CheckerUpdateAfterBeat();
                CheckForMoreBeating();
            }
        }

        public void CheckerUpdateAfterMove()
        {
            UpdateFieldTo();
            UpdateFieldFrom();
        }

        public void CheckerUpdateAfterBeat()
        {
            UpdateFieldThrough();
            UpdateFieldTo();
            UpdateFieldFrom();
        }

        public void CheckForMoreBeating()
        {
            GameService.forcedBeatingForPawnsList = pawn.GetDataAboutBeatings(COLOR);
            if (Extend.IsNullOrEmpty(GameService.forcedBeatingForPawnsList))
            {
                CheckIfThePawnHasReachedThePromotionField();
                FinishTheTurn(COLOR);
            }
            else
                RepeatTheTurn(COLOR);
        }

        public void CheckIfThePawnHasReachedThePromotionField()
        {
            if (Rule.ThePawnStoodInThePromotionField(indexTo, COLOR))
            {
                PromoteThePawn();
            }
        }

        public void UpdateFieldFrom()
        {
            fieldFrom.Image = new Bitmap(Properties.Resources.empty_field);
            GameService.gameBoard[indexFrom] = Constant.EMPTY_FIELD;
        }

        public void UpdateFieldThrough()
        {
            PictureBox fieldThrough = Extend.GetFieldByIndex(indexThrough);
            fieldThrough.Image = new Bitmap(Properties.Resources.empty_field);
            GameService.gameBoard[indexThrough] = Constant.EMPTY_FIELD;
        }

        public void UpdateFieldTo()
        {
            fieldTo.Image = fieldFrom.Image;
            GameService.gameBoard[indexTo] = GameService.gameBoard[indexFrom];
        }

        public void PromoteThePawn()
        {
            fieldTo.Image = Extend.GetDameImage(COLOR);
            GameService.gameBoard[indexTo] = Extend.GetDameField(COLOR);
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
