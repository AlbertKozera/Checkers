using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warcaby.CSharp.Config;
using Warcaby.CSharp.Dto;
using Warcaby.CSharp.Game.Computer;
using Warcaby.CSharp.Game.Computer.Impl;
using Warcaby.CSharp.Game.Context.Impl;
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
        GameLogicComputer gameLogicComputer = new GameLogicComputer();
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

            //PlayerVsPlayer(playerWhite, playerRed);
            PlayerVsComputer(playerWhite);
        }

        public void PlayerVsPlayer(GameLogic playerWhite, GameLogic playerRed)
        {
            if (whiteTurn)
                Human(playerWhite, Constant.WHITE);
            else
                Human(playerRed, Constant.RED);
        }

        public void PlayerVsComputer(GameLogic playerWhite)
        {
            if (whiteTurn)
                Human(playerWhite, Constant.WHITE);
            else
                Computer(Constant.RED);
        }

        public void Human(GameLogic player, string color)
        {
            forcedBeatingForPawnsList = pawn.GetDataAboutBeatings(color);
            forcedBeatingForDamesList = dame.GetDataAboutBeatings(color);
            player.MovingAPawnThatHasNoBeating();
            player.MovingADameThatHasNoBeating();
            player.MovingAPawnThatHasABeating();
            player.MovingADameThatHasABeating();
        }

        public void Computer(string color)
        {
            AI ai = new AI(color);
            Dictionary<int, Field> gameBoardCopy = Extend.CloneGameBoard(gameBoard);
            MoveAndPoints moveAndPoints = ai.MinMax(gameBoardCopy, color, true, 3);

            gameLogicComputer.UpdateFields(moveAndPoints);

            Extend.FinishTheTurn(color);
            Extend.ChangeImageOfTurn(Extend.GetEnemyPlayerColor(color));
        }
    }
}
