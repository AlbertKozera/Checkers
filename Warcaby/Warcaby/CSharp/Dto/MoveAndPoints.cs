

namespace Warcaby.CSharp.Dto
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
