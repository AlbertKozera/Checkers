using System;
using Warcaby.Service.Rules;

namespace Warcaby.CSharp.Game.Rules
{
    public class CommonCondition
    {
        public static Boolean ThePieceHaveABeat(string color, int indexTo)
        {
            return GameService.gameBoard[indexTo].isPawn
            ? PawnCondition.ThePawnHasABeat(color, indexTo)
            : DameCondition.TheDameHasABeat(color, indexTo);
        }

        public static Boolean ThereAreForcedBeatings()
        {
            return PawnCondition.ThereAreForcedBeatingsForPawns() || DameCondition.ThereAreForcedBeatingsForDames();
        }

        public static Boolean CheckIfAnyPieceIsInTheProcessOfMultipleBeatings(int index)
        {
            return index.Equals(0) ? false : true;
        }

        public static Boolean TheFieldWhereThePieceHasBeenDroppedIsEmpty(int index)
        {
            return GameService.gameBoard[index].isEmptyField;
        }

        public static Boolean SelectedPieceColorIs(int index, string color)
        {
            return GameService.gameBoard[index].color.Equals(color);
        }
    }
}
