using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warcaby.CSharp.Config;
using Warcaby.CSharp.GameRules.Human.Logic;
using Warcaby.Forms;


namespace Warcaby.Service.Human
{
    public class GameService
    {
        public static Dictionary<int, Field> gameBoard = new Dictionary<int, Field>();
        public static List<Tuple<int, int, int>> forcedBeatingForPawnsList;
        public static Dictionary<Tuple<int, int>, List<int>> forcedBeatingForDamesList;
        public static Boolean whiteTurn;
        Pawn pawn = new Pawn();
        Dame dame = new Dame();
        

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
            forcedBeatingForPawnsList = pawn.GetDataAboutBeatings(color);
            forcedBeatingForDamesList = dame.GetDataAboutBeatings(color);
            player.MovingAPawnThatHasNoBeating();
            player.MovingADameThatHasNoBeating();
            player.MovingAPawnThatHasABeating();
            player.MovingADameThatHasABeating();
        }
    }
}
