using System;
using System.Collections.Generic;
using Warcaby.Forms;
using Warcaby.Service.Human;

namespace Warcaby.CSharp.GameRules.Human.Logic
{
    public class Rule
    {
        public static Boolean SelectedPieceColorIs(int indexFrom, string color)
        {
            return GameService.gameBoard[indexFrom].color.Equals(color);
        }

        public static Boolean SelectedPieceIsPawn(int indexFrom)
        {
            return GameService.gameBoard[indexFrom].isPawn;
        }
        public static Boolean SelectedPieceIsDame(int indexFrom)
        {
            return GameService.gameBoard[indexFrom].isDame;
        }

        public static Boolean ThereAreForcedBeatingsForPawns()
        {
            return !Extend.IsNullOrEmpty(GameService.forcedBeatingForPawnsList);
        }

        public static Boolean ThereAreForcedBeatingsForDames()
        {
            return !Extend.IsNullOrEmpty(GameService.forcedBeatingForDamesList);
        }

        public static Boolean TheFieldWhereThePieceHasBeenDroppedIsEmpty(int indexTo)
        {
            return GameService.gameBoard[indexTo].isEmptyField;
        }

        public static Boolean ThePawnWasMovedAccordingToTheRules(int indexFrom, int indexTo, string color)
        {
            return color.Equals(Constant.WHITE)
                ? indexTo.Equals(indexFrom + 7) || indexTo.Equals(indexFrom + 9)
                : indexTo.Equals(indexFrom - 7) || indexTo.Equals(indexFrom - 9);
        }

        public static Boolean ThePawnWasBeatedAccordingToTheRules(int indexFrom, int indexTo)
        {
            return indexTo == indexFrom - 14 || indexTo == indexFrom - 18 || indexTo == indexFrom + 14 || indexTo == indexFrom + 18;
        }

        public static Boolean ThePawnStoodInThePromotionField(int indexTo, string color)
        {
            List<int> listOfPromotionalFieldsForWhite = new List<int>(new int[] { 57, 59, 61, 63 });
            List<int> listOfPromotionalFieldsForRed = new List<int>(new int[] { 2, 4, 6, 8 });            
            return color.Equals(Constant.WHITE)
                ? listOfPromotionalFieldsForWhite.Contains(indexTo)
                : listOfPromotionalFieldsForRed.Contains(indexTo);
        }

        public static Boolean ThePawnWantsToMoveProperly(int indexFrom, int indexTo, string color)
        {
            return Rule.SelectedPieceColorIs(indexFrom, color)
                && Rule.SelectedPieceIsPawn(indexFrom)
                && !Rule.ThereAreForcedBeatingsForPawns()
                && !Rule.ThereAreForcedBeatingsForDames()
                && Rule.ThePawnWasMovedAccordingToTheRules(indexFrom, indexTo, color)
                && Rule.TheFieldWhereThePieceHasBeenDroppedIsEmpty(indexTo);
        }

        public static Boolean PawnWantToExecuteBeatProperly(int indexFrom, int indexTo, string color)
        {
            return Rule.SelectedPieceColorIs(indexFrom, color)
                && Rule.SelectedPieceIsPawn(indexFrom)
                && Rule.ThereAreForcedBeatingsForPawns()
                && Rule.ThePawnWasBeatedAccordingToTheRules(indexFrom, indexTo)
                && Rule.TheFieldWhereThePieceHasBeenDroppedIsEmpty(indexTo);
        }
    }
}
