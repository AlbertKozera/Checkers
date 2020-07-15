using System;
using System.Collections.Generic;
using Warcaby.Forms;
using Warcaby.Service.Context;


namespace Warcaby.CSharp.Game.Context
{
    public class Dame
    {
        public Dictionary<Tuple<int, int>, List<int>> anyBeatings = new Dictionary<Tuple<int, int>, List<int>>();
        public List<int> allowedMoves = new List<int>();


        public Dictionary<Tuple<int, int>, List<int>> GetDataAboutBeatings(string myColor)
        {
            anyBeatings.Clear();
            SearchDiagonalForBeatings(myColor, Constant.TOP_RIGHT);
            SearchDiagonalForBeatings(myColor, Constant.DOWN_LEFT);
            SearchDiagonalForBeatings(myColor, Constant.TOP_LEFT);
            SearchDiagonalForBeatings(myColor, Constant.DOWN_RIGHT);
            return anyBeatings;
        }

        public List<int> GetAllowedMoves(int index)
        {
            allowedMoves.Clear();
            SearchDiagonalForEmptyFields(index, Constant.TOP_RIGHT);
            SearchDiagonalForEmptyFields(index, Constant.DOWN_LEFT);
            SearchDiagonalForEmptyFields(index, Constant.TOP_LEFT);
            SearchDiagonalForEmptyFields(index, Constant.DOWN_RIGHT);
            return allowedMoves;
        }

        public List<int> SearchDiagonalForEmptyFields(int index, int diagonal)
        {
            while (GameService.gameBoard.TryGetValue(index += diagonal, out Field field))
            {
                if (field.isEmptyField)
                    allowedMoves.Add(index);
                else
                    break;
            }
            return allowedMoves;
        }

        public void SearchDiagonalForBeatings(string myColor, int diagonal)
        {
            string enemyColor = Extend.GetEnemyPlayerColor(myColor);
            Field field;
            foreach (int index in GameService.gameBoard.Keys)
            {
                if (Rule.SelectedPieceIsDame(index) && Rule.SelectedPieceColorIs(index, myColor))
                {
                    int currentIndex = index;
                    int indexFrom = index;
                    while (GameService.gameBoard.TryGetValue(currentIndex += diagonal, out field))
                    {
                        if (field.color.Equals(enemyColor) && (GameService.gameBoard.TryGetValue(currentIndex + diagonal, out Field fieldBehind)))
                        {
                            if (fieldBehind.isEmptyField)
                            {
                                List<int> indexToList = new List<int>();
                                int indexThrough = currentIndex;
                                while (GameService.gameBoard.TryGetValue(currentIndex += diagonal, out field) && field.isEmptyField)
                                    indexToList.Add(currentIndex);
                                anyBeatings.Add(Tuple.Create(indexFrom, indexThrough), indexToList);
                                break;
                            }
                            else
                                break;
                        }
                    }
                }
            }
        }

        public int GetIndexThrough(string myColor, int indexFrom, int indexTo)
        {
            int largerIndex = Math.Max(indexFrom, indexTo);
            int smallerIndex = Math.Min(indexFrom, indexTo);
            int difference = (largerIndex - smallerIndex);
            if (difference % 9 == 0)
                difference = 9;
            else
                difference = 7;

            if (largerIndex == indexFrom && difference == 9)
                return GetIndexThroughByDiagonal(myColor, indexFrom, Constant.TOP_LEFT);
            else if (largerIndex == indexFrom && difference == 7)
                return GetIndexThroughByDiagonal(myColor, indexFrom, Constant.TOP_RIGHT);
            else if (largerIndex == indexTo && difference == 9)
                return GetIndexThroughByDiagonal(myColor, indexFrom, Constant.DOWN_RIGHT);
            else if (largerIndex == indexTo && difference == 7)
                return GetIndexThroughByDiagonal(myColor, indexFrom, Constant.DOWN_LEFT);
            return 0;
        }

        public int GetIndexThroughByDiagonal(string myColor, int indexFrom, int diagonal)
        {
            string enemyColor = Extend.GetEnemyPlayerColor(myColor);
            indexFrom += diagonal;
            while (GameService.gameBoard.ContainsKey(indexFrom))
            {
                if (GameService.gameBoard[indexFrom].color.Equals(myColor))
                    break;
                if (GameService.gameBoard[indexFrom].color.Equals(enemyColor))
                    return indexFrom;
                indexFrom += diagonal;
            }
            return 0;
        }
    }
}
