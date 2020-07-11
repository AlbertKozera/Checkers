

namespace Warcaby.Forms
{
    public sealed class Constant
    {
        public static readonly Field PAWN_WHITE = new Field(false, true, false, "white");
        public static readonly Field PAWN_RED = new Field(false, true, false, "red");
        public static readonly Field EMPTY_FIELD = new Field(true, false, false, "");
        public static readonly string WHITE = "white";
        public static readonly string RED = "red";
        public static readonly string EMPTY = "";
        public static readonly string FIELD = "field_";
    }
}
