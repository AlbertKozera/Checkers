using NLog;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warcaby.CSharp.Config;
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
        public int indexFrom;
        public int indexTo;
        public PictureBox fieldFrom;
        public PictureBox fieldTo;
        Pawn pawn = new Pawn();
        Dame dame = new Dame();
        LoggerService logger = new LoggerService();


        public GameService()
        {
            Initializer.SpaceThePawns();
            whiteTurn = true;
        }

        public void GameConstructor(PictureBox fieldFrom, PictureBox fieldTo)
        {
            this.indexFrom = Extend.GetIndexFromField(fieldFrom);
            this.indexTo = Extend.GetIndexFromField(fieldTo);
            this.fieldFrom = fieldFrom;
            this.fieldTo = fieldTo;
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
            var watch = System.Diagnostics.Stopwatch.StartNew();
            forcedBeatingForPawnsList = pawn.GetDataAboutBeatings(color);
            forcedBeatingForDamesList = dame.GetDataAboutBeatings(color);
            player.MovingAPawnThatHasNoBeating();
            player.MovingADameThatHasNoBeating();
            player.MovingAPawnThatHasABeating();
            player.MovingADameThatHasABeating();
            watch.Stop();
            var elapsed = watch.ElapsedMilliseconds;
            logger.WriteLogger(whiteTurn, indexFrom, GameLogic.indexThrough, indexTo, fieldFrom, fieldTo, elapsed);
        }
    }
}
