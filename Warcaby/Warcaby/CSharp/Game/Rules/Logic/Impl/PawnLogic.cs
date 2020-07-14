using System;
using System.Collections.Generic;
using Warcaby.Forms;
using Warcaby.Service.Rules;

namespace Warcaby.CSharp.Game.Rules
{
    public class PawnLogic : Contest
    {
        public List<Tuple<int, int, int>> anyBeatings = new List<Tuple<int, int, int>>();

        public void MovingAPawnThatHasNoBeating()
        {
            if (PawnCondition.ThePawnWantsToMoveProperly(indexFrom, indexTo, COLOR))
            {
                commonLogic.CheckerUpdateAfterMove();
                CheckIfThePawnHasReachedThePromotionField();
                commonLogic.FinishTheTurn(COLOR);
            }
        }

        public void MovingAPawnThatHasABeating()
        {
            if (CommonCondition.CheckIfAnyPieceIsInTheProcessOfMultipleBeatings(indexWhichHaveMultipleBeats))
            {
                if (PawnCondition.ThePawnWantToExecuteMultipleBeatProperly(indexFrom, indexTo, indexWhichHaveMultipleBeats, COLOR))
                {
                    commonLogic.CheckerUpdateAfterBeat();
                    commonLogic.CheckForMoreBeating();
                }
            }
            else if (PawnCondition.ThePawnWantToExecuteBeatProperly(indexFrom, indexTo, COLOR))
            {
                commonLogic.CheckerUpdateAfterBeat();
                commonLogic.CheckForMoreBeating();
            }
        }

        public List<Tuple<int, int, int>> GetDataAboutBeatings(string myColor)
        {
            anyBeatings.Clear();
            SearchDiagonalForBeatings(myColor, Constant.TOP_LEFT);
            SearchDiagonalForBeatings(myColor, Constant.TOP_RIGHT);
            SearchDiagonalForBeatings(myColor, Constant.DOWN_LEFT);
            SearchDiagonalForBeatings(myColor, Constant.DOWN_RIGHT);
            return anyBeatings;
        }

        public int GetIndexThrough(int indexFrom, int indexTo)
        {
            int largerIndex = Math.Max(indexFrom, indexTo);
            int smallerIndex = Math.Min(indexFrom, indexTo);
            int difference = (largerIndex - smallerIndex) / 2;
            if (difference == 9)
                return largerIndex - 9;
            else
                return largerIndex - 7;
        }

        public void SearchDiagonalForBeatings(string myColor, int diagonal)
        {
            Field fieldData;
            string enemyColor = Extend.GetEnemyPlayerColor(myColor);
            foreach (int i in GameService.gameBoard.Keys)
            {
                if (GameService.gameBoard.TryGetValue(i, out fieldData) && fieldData.color.Equals(myColor))
                {
                    if (GameService.gameBoard.TryGetValue(i + diagonal, out fieldData) && fieldData.color.Equals(enemyColor))
                    {
                        if (GameService.gameBoard.TryGetValue(i + (2 * diagonal), out fieldData) && fieldData.isEmptyField)
                        {
                            anyBeatings.Add(new Tuple<int, int, int>(i, i + diagonal, i + (2 * diagonal)));
                        }
                    }
                }
            }
        }
        
        public void PromoteThePawn()
        {
            fieldTo.Image = Extend.GetDameImage(COLOR);
            GameService.gameBoard[indexTo] = Extend.GetDameField(COLOR);
        }

        public void CheckIfThePawnHasReachedThePromotionField()
        {
            if (PawnCondition.ThePawnStoodInThePromotionField(indexTo, COLOR))
            {
                PromoteThePawn();
            }
        }
    }
}
