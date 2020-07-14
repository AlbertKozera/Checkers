using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcaby.CSharp.Game.Rules
{
    public interface IPiece
    {
        List<int> GetAllowedMoves(int index);
        Dictionary<Tuple<int, int>, List<int>> GetDataAboutBeatings(string myColor);
        void SearchDiagonalForBeatings(string myColor, int diagonal);
        int GetIndexThrough(string myColor, int indexFrom, int indexTo);
        int GetIndexThrough(int indexFrom, int indexTo);


    }
}
