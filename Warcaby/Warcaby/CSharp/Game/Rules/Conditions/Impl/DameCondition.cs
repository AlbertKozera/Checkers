using System;
using System.Collections.Generic;
using Warcaby.Forms;
using Warcaby.Service.Rules;

namespace Warcaby.CSharp.Game.Rules
{
    public class DameCondition
    {
        public static Boolean SelectedPieceIsDame(int index)
        {
            return GameService.gameBoard[index].isDame;
        }

        public static Boolean ThereAreForcedBeatingsForDames()
        {
            return !Extend.IsNullOrEmpty(GameService.forcedBeatingForDamesList);
        }

        public static Boolean TheDameWasMovedAccordingToTheRules(int indexFrom, int indexTo)
        {
            DameLogic dame = new DameLogic();
            return dame.GetAllowedMoves(indexFrom).Contains(indexTo);
        }

        public static Boolean TheDameWasBeatingAccordingToTheRules(int indexFrom, int indexTo, string color)
        {
            DameLogic dame = new DameLogic();
            foreach (KeyValuePair<Tuple<int, int>, List<int>> entry in GameService.forcedBeatingForDamesList)
            {
                if (entry.Key.Item1.Equals(indexFrom) && entry.Key.Item2.Equals(dame.GetIndexThrough(color, indexFrom, indexTo)) && entry.Value.Contains(indexTo))
                {
                    GameLogic.indexThrough = entry.Key.Item2;
                    return true;
                }
            }
            return false;
        }

        public static Boolean TheDameHasABeat(string myColor, int index)
        {
            return TheDameHasABeatOnSpecificDiagonal(myColor, index, Constant.TOP_LEFT)
                || TheDameHasABeatOnSpecificDiagonal(myColor, index, Constant.TOP_RIGHT)
                || TheDameHasABeatOnSpecificDiagonal(myColor, index, Constant.DOWN_LEFT)
                || TheDameHasABeatOnSpecificDiagonal(myColor, index, Constant.DOWN_RIGHT);
        }

        public static Boolean TheDameHasABeatOnSpecificDiagonal(string myColor, int index, int diagonal)
        {
            Field field;
            string enemyColor = Extend.GetEnemyPlayerColor(myColor);
            if (SelectedPieceIsDame(index) && CommonCondition.SelectedPieceColorIs(index, myColor))
            {
                int currentIndex = index;
                while (GameService.gameBoard.TryGetValue(currentIndex += diagonal, out field))
                {
                    if (field.color.Equals(enemyColor) && (GameService.gameBoard.TryGetValue(currentIndex + diagonal, out Field fieldBehind)))
                    {
                        return fieldBehind.isEmptyField;
                    }
                }
            }
            return false;
        }

        public static Boolean TheDameWantsToMoveProperly(int indexFrom, int indexTo, string color)
        {
            return CommonCondition.SelectedPieceColorIs(indexFrom, color)
                && SelectedPieceIsDame(indexFrom)
                && !CommonCondition.ThereAreForcedBeatings()
                && TheDameWasMovedAccordingToTheRules(indexFrom, indexTo)
                && CommonCondition.TheFieldWhereThePieceHasBeenDroppedIsEmpty(indexTo);
        }

        public static Boolean TheDameWantToExecuteBeatProperly(int indexFrom, int indexTo, string color)
        {
            return CommonCondition.SelectedPieceColorIs(indexFrom, color)
                && SelectedPieceIsDame(indexFrom)
                && ThereAreForcedBeatingsForDames()
                && TheDameWasBeatingAccordingToTheRules(indexFrom, indexTo, color);
            //&& Rule.TheFieldWhereThePieceHasBeenDroppedIsEmpty(indexTo);
        }

        public static Boolean TheDameWantToExecuteMultipleBeatProperly(int indexFrom, int indexTo, int indexWhichHaveMultipleBeats, string color)
        {
            return CommonCondition.SelectedPieceColorIs(indexFrom, color)
                && SelectedPieceIsDame(indexFrom)
                && ThereAreForcedBeatingsForDames()
                && indexFrom == indexWhichHaveMultipleBeats
                && TheDameWasBeatingAccordingToTheRules(indexFrom, indexTo, color);
            //&& Rule.TheFieldWhereThePieceHasBeenDroppedIsEmpty(indexTo);
        }
    }
}
