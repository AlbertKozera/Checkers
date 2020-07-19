using System;
using System.Collections.Generic;
using Warcaby.CSharp.Game;

namespace Warcaby.CSharp.Game
{
    public class MoveAndPoints
    {
        public int points { get; set; }
        public Move move { get; set; }

        public MoveAndPoints(int points, Move move)
        {
            this.points = points;
            this.move = move;
        }

        public MoveAndPoints()
        {
        }
    }
}
