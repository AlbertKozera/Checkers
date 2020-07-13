

namespace Warcaby.Forms
{
    public sealed class Constant
    {
        public static readonly string WHITE = "white";
        public static readonly string RED = "red";
        public static readonly string EMPTY = "";
        public static readonly Field PAWN_WHITE = new Field(false, true, false, WHITE);
        public static readonly Field DAME_WHITE = new Field(false, false, true, WHITE);
        public static readonly Field PAWN_RED = new Field(false, true, false, RED);
        public static readonly Field DAME_RED = new Field(false, false, true, RED);
        public static readonly Field EMPTY_FIELD = new Field(true, false, false, EMPTY);
    }
}
