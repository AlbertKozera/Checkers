using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Warcaby.Service.Human;


namespace Warcaby.Forms
{
    public class Common
    {
        public List<Tuple<int, int, int>> anyBeatingForPawns = new List<Tuple<int, int, int>>();
        public Dictionary<Tuple<int, int>, List<int>> anyBeatingForDames = new Dictionary<Tuple<int, int>, List<int>>();
        public List<int> allowedMovesForADame = new List<int>();
        public const int TOP_LEFT = -9;
        public const int TOP_RIGHT = -7;
        public const int DOWN_LEFT = +7;
        public const int DOWN_RIGHT = +9;


        public List<Tuple<int, int, int>> GetDataAboutBeatingsForPawns(Dictionary<int, Field> gameBoard, string myColor)
        {
            anyBeatingForPawns.Clear();
            string enemyColor = Extend.GetEnemyPlayerColor(myColor);

            Field fieldData;
            foreach (int i in gameBoard.Keys)
            {
                if (gameBoard.TryGetValue(i, out fieldData) && fieldData.color.Equals(myColor))
                {
                    if (gameBoard.TryGetValue(i + 7, out fieldData) && fieldData.color.Equals(enemyColor)) //Lewy dolny róg
                    {
                        if (gameBoard.TryGetValue(i + 14, out fieldData) && fieldData.isEmptyField)
                        {
                            anyBeatingForPawns.Add(new Tuple<int, int, int>(i, i + 14, i + 7));
                        }
                    }
                    if (gameBoard.TryGetValue(i - 7, out fieldData) && fieldData.color.Equals(enemyColor)) //prawy górny róg
                    {
                        if (gameBoard.TryGetValue(i - 14, out fieldData) && fieldData.isEmptyField)
                        {
                            anyBeatingForPawns.Add(new Tuple<int, int, int>(i, i - 14, i - 7));
                        }
                    }
                    if (gameBoard.TryGetValue(i + 9, out fieldData) && fieldData.color.Equals(enemyColor)) //prawy dolny róg
                    {
                        if (gameBoard.TryGetValue(i + 18, out fieldData) && fieldData.isEmptyField)
                        {
                            anyBeatingForPawns.Add(new Tuple<int, int, int>(i, i + 18, i + 9));
                        }
                    }
                    if (gameBoard.TryGetValue(i - 9, out fieldData) && fieldData.color.Equals(enemyColor)) //lewy górny róg
                    {
                        if (gameBoard.TryGetValue(i - 18, out fieldData) && fieldData.isEmptyField)
                        {
                            anyBeatingForPawns.Add(new Tuple<int, int, int>(i, i - 18, i - 9));
                        }
                    }
                }
            }
            return anyBeatingForPawns;
        }

        public Dictionary<Tuple<int, int>, List<int>> GetDataAboutBeatingsForDames(string myColor)
        {
            anyBeatingForDames.Clear();
            SearchDiagonalForBeatings(myColor, TOP_RIGHT);
            SearchDiagonalForBeatings(myColor, DOWN_LEFT);
            SearchDiagonalForBeatings(myColor, TOP_LEFT);
            SearchDiagonalForBeatings(myColor, DOWN_RIGHT);
            return anyBeatingForDames;
        }

        public List<int> GetAllowedMovesForADame(int index)
        {
            allowedMovesForADame.Clear();
            SearchDiagonalForEmptyFields(index, TOP_RIGHT);
            SearchDiagonalForEmptyFields(index, DOWN_LEFT);
            SearchDiagonalForEmptyFields(index, TOP_LEFT);
            SearchDiagonalForEmptyFields(index, DOWN_RIGHT);
            return allowedMovesForADame;
        }

        public List<int> SearchDiagonalForEmptyFields(int index, int corner)
        {
            while (GameService.gameBoard.TryGetValue(index += corner, out Field field))
            {
                if(field.isEmptyField)
                    allowedMovesForADame.Add(index);
                else
                    break;
            }
            return allowedMovesForADame;
        }

        public void SearchDiagonalForBeatings(string myColor, int corner)
        {
            string enemyColor = Extend.GetEnemyPlayerColor(myColor);
            Field field;
            foreach (int index in GameService.gameBoard.Keys)
            {
                if (GameService.gameBoard[index].isDame && GameService.gameBoard[index].color.Equals(myColor))
                {
                    int currentIndex = index;
                    int indexFrom = index;
                    while (GameService.gameBoard.TryGetValue(currentIndex += corner, out field))
                    {
                        if (field.color.Equals(enemyColor) && (GameService.gameBoard.TryGetValue(currentIndex + corner, out Field fieldBehind)))
                        {
                            if (fieldBehind.isEmptyField)
                            {
                                List<int> indexToList = new List<int>();
                                int indexThrough = currentIndex;
                                while (GameService.gameBoard.TryGetValue(currentIndex += corner, out field) && field.isEmptyField)
                                    indexToList.Add(currentIndex);
                                anyBeatingForDames.Add(Tuple.Create(indexFrom, indexThrough), indexToList);
                                break;
                            }
                            else
                                break;
                        }
                    }
                }
            }
        }

    }
}
