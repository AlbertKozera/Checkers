using System;
using System.Collections.Generic;
using Warcaby.Forms;
using Warcaby.Service.Human;

namespace Warcaby.CSharp.GameRules.Human.Logic
{
    public class Pawn
    {
        public List<Tuple<int, int, int>> anyBeatings = new List<Tuple<int, int, int>>();


        public List<Tuple<int, int, int>> GetDataAboutBeatings(string myColor)
        {
            anyBeatings.Clear();
            SearchDiagonalForBeatings(myColor, Constant.TOP_LEFT);
            SearchDiagonalForBeatings(myColor, Constant.TOP_RIGHT);
            SearchDiagonalForBeatings(myColor, Constant.DOWN_LEFT);
            SearchDiagonalForBeatings(myColor, Constant.DOWN_RIGHT);
            return anyBeatings;
        }

        private void SearchDiagonalForBeatings(string myColor, int diagonal)
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
    }
}
