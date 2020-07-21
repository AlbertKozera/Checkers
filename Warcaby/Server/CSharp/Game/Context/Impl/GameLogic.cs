using Server;
using System.Drawing;
using System.Windows.Forms;
using Warcaby.CSharp.Config;
using Warcaby.Forms;
using Warcaby.Service.Context;


namespace Warcaby.CSharp.Game.Context.Impl
{
    public class GameLogic
    {
        int indexFrom;
        public static int indexWhichHaveMultipleBeats;
        public static int indexThrough;
        int indexTo;
        string COLOR;
        Pawn pawn = new Pawn();
        Dame dame = new Dame();


        public GameLogic(int indexFrom, int indexTo, string COLOR)
        {
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
            ServerStage.SendRespondToClient("move_pawn_" + COLOR + "_" + indexFrom + "_" + indexTo); // wykonano poprawny ruch - pionem;
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
            GameService.gameBoard[indexFrom] = Constant.EMPTY_FIELD;
        }

        public void UpdateFieldThrough()
        {
            GameService.gameBoard[indexThrough] = Constant.EMPTY_FIELD;
            Extend.UpdateGuiCounters();
            Extend.CheckIfAnyoneAlreadyWon();
        }

        public void UpdateFieldTo()
        {
            GameService.gameBoard[indexTo] = GameService.gameBoard[indexFrom];
        }

        public void PromoteThePawn()
        {
            GameService.gameBoard[indexTo] = Extend.GetDameField(COLOR);
        }
    }
}
