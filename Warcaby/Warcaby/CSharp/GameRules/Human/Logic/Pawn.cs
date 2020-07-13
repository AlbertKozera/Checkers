using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warcaby.Forms;
using Warcaby.Service.Human;

namespace Warcaby.CSharp.GameRules.Human.Logic
{
    public class Pawn
    {
        public List<Tuple<int, int, int>> anyBeatingForPawns = new List<Tuple<int, int, int>>();
        public Dictionary<Tuple<int, int>, List<int>> anyBeatingForDames = new Dictionary<Tuple<int, int>, List<int>>();
        public List<int> allowedMovesForADame = new List<int>();
        public const int TOP_LEFT = -9;
        public const int TOP_RIGHT = -7;
        public const int DOWN_LEFT = +7;
        public const int DOWN_RIGHT = +9;


        public List<Tuple<int, int, int>> GetDataAboutBeatings(string myColor)
        {
            anyBeatingForPawns.Clear();
            SearchDiagonalForBeatings(myColor, TOP_LEFT);
            SearchDiagonalForBeatings(myColor, TOP_RIGHT);
            SearchDiagonalForBeatings(myColor, DOWN_LEFT);
            SearchDiagonalForBeatings(myColor, DOWN_RIGHT);
            return anyBeatingForPawns;
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
                            anyBeatingForPawns.Add(new Tuple<int, int, int>(i, i + (2 * corner), i + corner));
                        }
                    }
                }
            }
        }
    }
}
