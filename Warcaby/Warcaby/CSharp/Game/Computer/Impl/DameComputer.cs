using System.Collections.Generic;
using System.Linq;
using Warcaby.CSharp.Config;
using Warcaby.CSharp.Dto;
using Warcaby.Forms;


namespace Warcaby.CSharp.Game.Context
{
    public class DameComputer
    {
        public List<Move> GetMovesForFieldByIndex(int i, Dictionary<int, Field> gameBoard)
        {
            List<Move> indexToList = new List<Move>();

            var top_left_diagonal = SearchDiagonalForPossibleMoves(i, Constant.TOP_LEFT, gameBoard);
            var top_right_diagonal = SearchDiagonalForPossibleMoves(i, Constant.TOP_RIGHT, gameBoard);
            var down_left_diagonal = SearchDiagonalForPossibleMoves(i, Constant.DOWN_LEFT, gameBoard);
            var down_right_diagonal = SearchDiagonalForPossibleMoves(i, Constant.DOWN_RIGHT, gameBoard);

            if (!top_left_diagonal.IsNullOrEmpty())
                indexToList.AddRange(top_left_diagonal);
            if (!top_right_diagonal.IsNullOrEmpty())
                indexToList.AddRange(top_right_diagonal);
            if (!down_left_diagonal.IsNullOrEmpty())
                indexToList.AddRange(down_left_diagonal);
            if (!down_right_diagonal.IsNullOrEmpty())
                indexToList.AddRange(down_right_diagonal);

            return indexToList;
        }

        public List<Move> GetBeatingForFieldOnSpecificDiagonal(int i, string enemyColor, int diagonal, Dictionary<int, Field> gameBoard)
        {
            Field field;
            int indexFrom = i;
            while (gameBoard.TryGetValue(i += diagonal, out field))
            {
                if (field.color.Equals(enemyColor) && (gameBoard.TryGetValue(i + diagonal, out Field fieldBehind)))
                {
                    if (fieldBehind.isEmptyField)
                    {
                        List<Move> possibleMovesList = new List<Move>();
                        int indexThrough = i;
                        while (gameBoard.TryGetValue(i += diagonal, out field) && field.isEmptyField)
                            possibleMovesList.Add(new Move(indexFrom, indexThrough, i, gameBoard[indexFrom], gameBoard[indexThrough], gameBoard[i]));
                        return possibleMovesList;
                    }
                    else
                        return null;
                }
            }
            return null;
        }

        public List<Move> GetPossibleMovesForField(int i, string myColor, Dictionary<int, Field> gameBoard)
        {
            List<Move> possibleMovesList = new List<Move>();
            string enemyColor = Extend.GetEnemyPlayerColor(myColor);

            var top_left_diagonal = GetBeatingForFieldOnSpecificDiagonal(i, enemyColor, Constant.TOP_LEFT, gameBoard);
            var top_right_diagonal = GetBeatingForFieldOnSpecificDiagonal(i, enemyColor, Constant.TOP_RIGHT, gameBoard);
            var down_left_diagonal = GetBeatingForFieldOnSpecificDiagonal(i, enemyColor, Constant.DOWN_LEFT, gameBoard);
            var down_right_diagonal = GetBeatingForFieldOnSpecificDiagonal(i, enemyColor, Constant.DOWN_RIGHT, gameBoard);

            if(!top_left_diagonal.IsNullOrEmpty())
                possibleMovesList.AddRange(top_left_diagonal);
            if (!top_right_diagonal.IsNullOrEmpty())
                possibleMovesList.AddRange(top_right_diagonal);
            if (!down_left_diagonal.IsNullOrEmpty())
                possibleMovesList.AddRange(down_left_diagonal);
            if (!down_right_diagonal.IsNullOrEmpty())
                possibleMovesList.AddRange(down_right_diagonal);


            possibleMovesList = possibleMovesList.Where(l => l != null).ToList();

            if (possibleMovesList.IsNullOrEmpty())
            {
                possibleMovesList.AddRange(GetMovesForFieldByIndex(i, gameBoard));
            }

            return possibleMovesList;
        }

        public List<Move> SearchDiagonalForPossibleMoves(int i, int diagonal, Dictionary<int, Field> gameBoard)
        {
            List<Move> possibleMovesList = new List<Move>();
            int iDiagonal = i;
            while (gameBoard.TryGetValue(iDiagonal += diagonal, out Field field))
            {
                if (field.isEmptyField)
                    possibleMovesList.Add(new Move(i, iDiagonal, gameBoard[i], gameBoard[iDiagonal]));
                else
                    break;
            }
            return possibleMovesList;
        }
    }
}
