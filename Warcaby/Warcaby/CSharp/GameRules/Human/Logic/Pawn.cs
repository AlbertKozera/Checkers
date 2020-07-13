using System;
using System.Collections.Generic;
using Warcaby.Forms;
using Warcaby.Service.Human;

namespace Warcaby.CSharp.GameRules.Human.Logic
{
    public class Pawn
    {
        public List<Tuple<int, int, int>> anyBeatings = new List<Tuple<int, int, int>>();
        public const int TOP_LEFT = -9;
        public const int TOP_RIGHT = -7;
        public const int DOWN_LEFT = +7;
        public const int DOWN_RIGHT = +9;


        public List<Tuple<int, int, int>> GetDataAboutBeatings(string myColor)
        {
            anyBeatings.Clear();
            SearchDiagonalForBeatings(myColor, TOP_LEFT);
            SearchDiagonalForBeatings(myColor, TOP_RIGHT);
            SearchDiagonalForBeatings(myColor, DOWN_LEFT);
            SearchDiagonalForBeatings(myColor, DOWN_RIGHT);
            return anyBeatings;
        }

        private void SearchDiagonalForBeatings(string myColor, int corner)
        {
            Field fieldData;
            string enemyColor = Extend.GetEnemyPlayerColor(myColor);
            foreach (int i in GameService.gameBoard.Keys)
            {
                if (GameService.gameBoard.TryGetValue(i, out fieldData) && fieldData.color.Equals(myColor))
                {
                    if (GameService.gameBoard.TryGetValue(i + corner, out fieldData) && fieldData.color.Equals(enemyColor))
                    {
                        if (GameService.gameBoard.TryGetValue(i + (2 * corner), out fieldData) && fieldData.isEmptyField)
                        {
                            anyBeatings.Add(new Tuple<int, int, int>(i, i + corner, i + (2 * corner)));
                        }
                    }
                }
            }
        }
    }
}
