using System.Drawing;
using System.Windows.Forms;
using Warcaby.CSharp.Config;
using Warcaby.Forms;
using Warcaby.Service.Context;


namespace Warcaby.CSharp.Game.Context.Impl
{
    public class GameLogic
    {
        PictureBox fieldFrom;
        PictureBox fieldTo;
        int indexFrom;
        public static int indexWhichHaveMultipleBeats;
        public static int indexThrough;
        int indexTo;
        string COLOR;
        Pawn pawn = new Pawn();
        Dame dame = new Dame();


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
                Extend.FinishTheTurn(COLOR);
            }
        }

        public void MovingADameThatHasNoBeating()
        {
            if (Rule.TheDameWantsToMoveProperly(indexFrom, indexTo, COLOR))
            {
                CheckerUpdateAfterMove();
                Extend.FinishTheTurn(COLOR);
            }
        }

        public void MovingAPawnThatHasABeating()
        {
            if (Rule.CheckIfAnyPieceIsInTheProcessOfMultipleBeatings(indexWhichHaveMultipleBeats))
            {
                if (Rule.ThePawnWantToExecuteMultipleBeatProperly(indexFrom, indexTo, indexWhichHaveMultipleBeats, COLOR))
                {
                    CheckerUpdateAfterBeat();
                    CheckForMoreBeating();
                }
            }
            else if (Rule.ThePawnWantToExecuteBeatProperly(indexFrom, indexTo, COLOR))
            {
                CheckerUpdateAfterBeat();
                CheckForMoreBeating();
            }
        }

        public void MovingADameThatHasABeating()
        {
            if (Rule.CheckIfAnyPieceIsInTheProcessOfMultipleBeatings(indexWhichHaveMultipleBeats))
            {
                if (Rule.TheDameWantToExecuteMultipleBeatProperly(indexFrom, indexTo, indexWhichHaveMultipleBeats, COLOR))
                {
                    CheckerUpdateAfterBeat();
                    CheckForMoreBeating();
                }
            }
            else if (Rule.TheDameWantToExecuteBeatProperly(indexFrom, indexTo, COLOR))
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
            GameService.forcedBeatingForDamesList = dame.GetDataAboutBeatings(COLOR);
            if (Rule.ThePieceHaveABeat(COLOR, indexTo))
            {
                indexWhichHaveMultipleBeats = indexTo;
                Extend.RepeatTheTurn(COLOR);
            }
            else
            {
                if (Rule.SelectedPieceIsPawn(indexTo))
                    CheckIfThePawnHasReachedThePromotionField();
                indexWhichHaveMultipleBeats = 0;
                Extend.FinishTheTurn(COLOR);
            }
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
            Extend.UpdateGuiCounters();
            Extend.CheckIfAnyoneAlreadyWon();
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
            Extend.UpdateGuiCounters();
        }
    }
}
