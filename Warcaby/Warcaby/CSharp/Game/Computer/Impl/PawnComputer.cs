using System;
using System.Collections.Generic;
using System.Linq;
using Warcaby.CSharp.Config;
using Warcaby.CSharp.Dto;
using Warcaby.Forms;


namespace Warcaby.CSharp.Game.Context
{
    public class PawnComputer
    {

        public List<Move> GetMovesForFieldByIndex(int i, string enemyColor, Dictionary<int, Field> gameBoard)
        {
            Field field;
            List<Move> possibleMovesList = new List<Move>();
            if (enemyColor.Equals(Constant.WHITE))
            {
                if (gameBoard.TryGetValue(i + Constant.TOP_RIGHT, out field) && field.isEmptyField)
                    possibleMovesList.Add(new Move(i, i + Constant.TOP_RIGHT, gameBoard[i], gameBoard[i + Constant.TOP_RIGHT]));
                if (gameBoard.TryGetValue(i + Constant.TOP_LEFT, out field) && field.isEmptyField)
                    possibleMovesList.Add(new Move(i, i + Constant.TOP_LEFT, gameBoard[i], gameBoard[i + Constant.TOP_LEFT]));

                    return possibleMovesList;
            }
            else
            {
                if (gameBoard.TryGetValue(i + Constant.DOWN_RIGHT, out field) && field.isEmptyField)
                    possibleMovesList.Add(new Move(i, i + Constant.DOWN_RIGHT, gameBoard[i], gameBoard[i + Constant.DOWN_RIGHT]));
                if (gameBoard.TryGetValue(i + Constant.DOWN_LEFT, out field) && field.isEmptyField)
                    possibleMovesList.Add(new Move(i, i + Constant.DOWN_LEFT, gameBoard[i], gameBoard[i + Constant.DOWN_LEFT]));
                if (!possibleMovesList.IsNullOrEmpty())

                    return possibleMovesList;
            }
            return null;
        }

        public Move GetBeatingForFieldOnSpecificDiagonal(int i, string enemyColor, int diagonal, Dictionary<int, Field> gameBoard)
        {
            Field fieldData;
            if (gameBoard.TryGetValue(i + diagonal, out fieldData) && fieldData.color.Equals(enemyColor))
            {
                if (gameBoard.TryGetValue(i + (2 * diagonal), out fieldData) && fieldData.isEmptyField)
                {
                    return new Move(i, i + diagonal, i + (2 * diagonal), gameBoard[i], gameBoard[i + diagonal], gameBoard[i + (2 * diagonal)]);
                }
            }
            return null;
        }

        public List<Move> GetPossibleMovesForField(int i, string myColor, Dictionary<int, Field> gameBoard)
        {
            List<Move> possibleMovesList = new List<Move>();
            string enemyColor = Extend.GetEnemyPlayerColor(myColor);    
           
            possibleMovesList.Add(GetBeatingForFieldOnSpecificDiagonal(i, enemyColor, Constant.TOP_LEFT, gameBoard));
            possibleMovesList.Add(GetBeatingForFieldOnSpecificDiagonal(i, enemyColor, Constant.TOP_RIGHT, gameBoard));
            possibleMovesList.Add(GetBeatingForFieldOnSpecificDiagonal(i, enemyColor, Constant.DOWN_LEFT, gameBoard));
            possibleMovesList.Add(GetBeatingForFieldOnSpecificDiagonal(i, enemyColor, Constant.DOWN_RIGHT, gameBoard));
            possibleMovesList = possibleMovesList.Where(l => l != null).ToList();

            if (possibleMovesList.IsNullOrEmpty())
                if(GetMovesForFieldByIndex(i, enemyColor, gameBoard) != null)
                    possibleMovesList.AddRange(GetMovesForFieldByIndex(i, enemyColor, gameBoard));

            return possibleMovesList;
        }
    }
}
