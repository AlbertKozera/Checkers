using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warcaby.CSharp.Config;
using Warcaby.Forms;


namespace Warcaby.Service.Human
{
    public class GameService
    {
        public static Dictionary<int, Field> gameBoard = new Dictionary<int, Field>();
        public static List<Tuple<int, int, int>> forcedBeatingForPawnsList;
        public static Dictionary<Tuple<int, int>, List<int>> forcedBeatingForDamesList;
        public static Boolean whiteTurn;
        Common common = new Common();
        

        public GameService()
        {
            Initializer.SpaceThePawns();
            whiteTurn = true;
        }

        public void GameChooser(PictureBox fieldFrom, PictureBox fieldTo)
        {
            int indexFrom = Extend.GetIndexFromField(fieldFrom);
            int indexTo = Extend.GetIndexFromField(fieldTo);
            GameLogic playerWhite = new GameLogic(fieldFrom, fieldTo, indexFrom, indexTo, Constant.WHITE);
            GameLogic playerRed = new GameLogic(fieldFrom, fieldTo, indexFrom, indexTo, Constant.RED);

            if (whiteTurn)
                Gameplay(playerWhite, Constant.WHITE);
            else
                Gameplay(playerRed, Constant.RED);
        }

        public void Gameplay(GameLogic player, string color)
        {
            forcedBeatingForPawnsList = common.GetDataAboutBeatingsForPawns(gameBoard, color);
            //forcedBeatingForDamesList = common.GetDataAboutBeatingsForDames(color);
            player.MovingAPawnThatHasNoBeating();
            player.MovingAPawnThatHasABeating();
        }
    }
}
