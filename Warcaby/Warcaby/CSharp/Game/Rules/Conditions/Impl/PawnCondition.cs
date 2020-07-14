using System;
using System.Collections.Generic;
using Warcaby.Forms;
using Warcaby.Service.Rules;

namespace Warcaby.CSharp.Game.Rules
{
    public class PawnCondition
    {
        public static Boolean SelectedPieceIsPawn(int index)
        {
            return GameService.gameBoard[index].isPawn;
        }
        public static Boolean ThereAreForcedBeatingsForPawns()
        {
            return !Extend.IsNullOrEmpty(GameService.forcedBeatingForPawnsList);
        }

        public static Boolean ThePawnWasMovedAccordingToTheRules(int indexFrom, int indexTo, string color)
        {
            return color.Equals(Constant.WHITE)
                ? indexTo.Equals(indexFrom + 7) || indexTo.Equals(indexFrom + 9)
                : indexTo.Equals(indexFrom - 7) || indexTo.Equals(indexFrom - 9);
        }

        public static Boolean ThePawnWasBeatingAccordingToTheRules(int indexFrom, int indexTo)
        {
            PawnLogic pawn = new PawnLogic();
            foreach (Tuple<int, int, int> tuple in GameService.forcedBeatingForPawnsList)
            {
                if (tuple.Item1.Equals(indexFrom) && tuple.Item2.Equals(pawn.GetIndexThrough(indexFrom, indexTo)) && tuple.Item3.Equals(indexTo))
                {
                    GameLogic.indexThrough = tuple.Item2;
                    return true;
                }
            }
            return false;
        }

        public static Boolean ThePawnHasABeat(string myColor, int index)
        {
            return ThePawnHasABeatOnSpecificDiagonal(myColor, index, Constant.TOP_LEFT)
                || ThePawnHasABeatOnSpecificDiagonal(myColor, index, Constant.TOP_RIGHT)
                || ThePawnHasABeatOnSpecificDiagonal(myColor, index, Constant.DOWN_LEFT)
                || ThePawnHasABeatOnSpecificDiagonal(myColor, index, Constant.DOWN_RIGHT);
        }

        public static Boolean ThePawnHasABeatOnSpecificDiagonal(string myColor, int index, int diagonal)
        {
            Field fieldData;
            string enemyColor = Extend.GetEnemyPlayerColor(myColor);
            return (GameService.gameBoard.TryGetValue(index, out fieldData) && fieldData.color.Equals(myColor))
                && (GameService.gameBoard.TryGetValue(index + diagonal, out fieldData) && fieldData.color.Equals(enemyColor))
                && (GameService.gameBoard.TryGetValue(index + (2 * diagonal), out fieldData) && fieldData.isEmptyField);
        }

        public static Boolean ThePawnStoodInThePromotionField(int index, string color)
        {
            List<int> listOfPromotionalFieldsForWhite = new List<int>(new int[] { 57, 59, 61, 63 });
            List<int> listOfPromotionalFieldsForRed = new List<int>(new int[] { 2, 4, 6, 8 });
            return color.Equals(Constant.WHITE)
                ? listOfPromotionalFieldsForWhite.Contains(index)
                : listOfPromotionalFieldsForRed.Contains(index);
        }

        public static Boolean ThePawnWantsToMoveProperly(int indexFrom, int indexTo, string color)
        {
            return CommonCondition.SelectedPieceColorIs(indexFrom, color)
                && SelectedPieceIsPawn(indexFrom)
                && !CommonCondition.ThereAreForcedBeatings()
                && ThePawnWasMovedAccordingToTheRules(indexFrom, indexTo, color)
                && CommonCondition.TheFieldWhereThePieceHasBeenDroppedIsEmpty(indexTo);
        }

        public static Boolean ThePawnWantToExecuteBeatProperly(int indexFrom, int indexTo, string color)
        {
            return CommonCondition.SelectedPieceColorIs(indexFrom, color)
                && SelectedPieceIsPawn(indexFrom)
                && ThereAreForcedBeatingsForPawns()
                && ThePawnWasBeatingAccordingToTheRules(indexFrom, indexTo);
            //&& Rule.TheFieldWhereThePieceHasBeenDroppedIsEmpty(indexTo);
        }

        public static Boolean ThePawnWantToExecuteMultipleBeatProperly(int indexFrom, int indexTo, int indexWhichHaveMultipleBeats, string color)
        {
            return CommonCondition.SelectedPieceColorIs(indexFrom, color)
                && SelectedPieceIsPawn(indexFrom)
                && ThereAreForcedBeatingsForPawns()
                && indexFrom == indexWhichHaveMultipleBeats
                && ThePawnWasBeatingAccordingToTheRules(indexFrom, indexTo);
            //&& Rule.TheFieldWhereThePieceHasBeenDroppedIsEmpty(indexTo);
        }
    }
}
