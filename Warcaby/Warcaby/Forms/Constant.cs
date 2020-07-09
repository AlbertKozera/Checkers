using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warcaby.Forms
{
    public sealed class Constant
    {
        public static readonly Field PAWN_WHITE = new Field(false, true, false, "white");
        public static readonly Field PAWN_RED = new Field(false, true, false, "red");
        public static readonly Field EMPTY_FIELD = new Field(true, false, false, "");
    }
}
