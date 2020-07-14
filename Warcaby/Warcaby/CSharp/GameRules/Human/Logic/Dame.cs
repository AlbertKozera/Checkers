using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warcaby.Forms;
using Warcaby.Service.Human;

namespace Warcaby.CSharp.GameRules.Human.Logic
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

        private List<int> SearchDiagonalForEmptyFields(int index, int diagonal)
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

        private void SearchDiagonalForBeatings(string myColor, int diagonal)
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
    }
}
