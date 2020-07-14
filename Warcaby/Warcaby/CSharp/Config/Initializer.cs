using Warcaby.Forms;
using Warcaby.Service.Rules;

namespace Warcaby.CSharp.Config
{
    public class Initializer
    {
        public static void SpaceThePawns()
        {
            GameService.gameBoard.Clear();
            LoadWhitePawns();
            LoadEmptyFields();
            LoadRedPawns();
        }

        private static void LoadWhitePawns()
        {
            for (int i = 2; i <= 24; i += 2)
            {
                GameService.gameBoard.Add(i, Constant.PAWN_WHITE);
                if (i == 8) i--;
                if (i == 15) i++;
            }
        }

        private static void LoadEmptyFields()
        {
            for (int i = 25; i <= 40; i += 2)
            {
                GameService.gameBoard.Add(i, Constant.EMPTY_FIELD);
                if (i == 31) i++;
            }
        }

        private static void LoadRedPawns()
        {
            for (int i = 41; i <= 63; i += 2)
            {
                GameService.gameBoard.Add(i, Constant.PAWN_RED);
                if (i == 47) i++;
                if (i == 56) i--;
            }
        }
    }
}
