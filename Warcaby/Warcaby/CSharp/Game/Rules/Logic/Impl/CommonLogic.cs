using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Warcaby.Forms;
using Warcaby.Service.Rules;

namespace Warcaby.CSharp.Game.Rules
{
    public class CommonLogic
    {

        public void CheckForMoreBeating()
        {
            GameService.forcedBeatingForPawnsList = pawn.GetDataAboutBeatings(COLOR);
            GameService.forcedBeatingForDamesList = dame.GetDataAboutBeatings(COLOR);
            if (CommonCondition.ThePieceHaveABeat(COLOR, indexTo))
            {
                indexWhichHaveMultipleBeats = indexTo;
                RepeatTheTurn(COLOR);
            }
            else
            {
                if (PawnCondition.SelectedPieceIsPawn(indexTo))
                    pawn.CheckIfThePawnHasReachedThePromotionField();
                indexWhichHaveMultipleBeats = 0;
                FinishTheTurn(COLOR);
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
