using NLog;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warcaby.CSharp.Config;
using Warcaby.CSharp.Game;
using Warcaby.CSharp.Game.Computer;
using Warcaby.CSharp.Game.Context;
using Warcaby.CSharp.Service;
using Warcaby.Forms;


namespace Warcaby.Service.Context
{
    public class GameService
    {
        public static Dictionary<int, Field> gameBoard = new Dictionary<int, Field>();
        public static List<Tuple<int, int, int>> forcedBeatingForPawnsList;
        public static Dictionary<Tuple<int, int>, List<int>> forcedBeatingForDamesList;
        public static Boolean whiteTurn;
        public static int indexFrom;
        public static int indexTo;
        public static PictureBox fieldFrom;
        public static PictureBox fieldTo;
        Pawn pawn = new Pawn();
        Dame dame = new Dame();

        public GameService()
        {
            Initializer.SpaceThePawns();
            whiteTurn = true;
        }

        public void GameConstructor(PictureBox fieldFrom, PictureBox fieldTo)
        {
            GameService.indexFrom = Extend.GetIndexFromField(fieldFrom);
            GameService.indexTo = Extend.GetIndexFromField(fieldTo);
            GameService.fieldFrom = fieldFrom;
            GameService.fieldTo = fieldTo;
        }

        public void GameChooser(PictureBox fieldFrom, PictureBox fieldTo)
        {
            GameConstructor(fieldFrom, fieldTo);
            GameLogic playerWhite = new GameLogic(fieldFrom, fieldTo, indexFrom, indexTo, Constant.WHITE);
            GameLogic playerRed = new GameLogic(fieldFrom, fieldTo, indexFrom, indexTo, Constant.RED);

            if (whiteTurn)
                Gameplay(playerWhite, Constant.WHITE);
            else
                Gameplay(playerRed, Constant.RED);
        }

        public void Gameplay(GameLogic player, string color)
        {
            ComputerLogic computerLogic = new ComputerLogic();
            List<Move> list = computerLogic.GetPossibleMoves(gameBoard, color);




            forcedBeatingForPawnsList = pawn.GetDataAboutBeatings(color);
            forcedBeatingForDamesList = dame.GetDataAboutBeatings(color);
            player.MovingAPawnThatHasNoBeating();
            player.MovingADameThatHasNoBeating();
            player.MovingAPawnThatHasABeating();
            player.MovingADameThatHasABeating();
        }
    }
}
