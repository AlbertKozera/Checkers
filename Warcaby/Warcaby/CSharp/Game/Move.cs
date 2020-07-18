using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcaby.CSharp.Game
{
    public class Move
    {
        public int indexFrom { get; set; }
        public int indexThrough { get; set; }
        public int indexTo { get; set; }

        public Move(int indexFrom, int indexTo)
        {
            this.indexFrom = indexFrom;
            this.indexTo = indexTo;
        }

        public Move(int indexFrom, int indexThrough, int indexTo)
        {
            this.indexFrom = indexFrom;
            this.indexThrough = indexThrough;
            this.indexTo = indexTo;
        }

    }
}
