using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warcaby.CSharp.Config;
using Warcaby.CSharp.Dto;
using Warcaby.CSharp.Game.Computer;
using Warcaby.CSharp.Game.Computer.Impl;
using Warcaby.CSharp.Game.Context.Impl;
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
        GameLogicComputer gameLogicComputer = new GameLogicComputer();
        Pawn pawn = new Pawn();
        Dame dame = new Dame();

        public GameService()
        {
            Initializer.SpaceThePawns();
            whiteTurn = true;
        }


        public void GameChooser(int indexFrom, int indexTo, string color, int typeOfGame)
        {
            GameLogic playerWhite = new GameLogic(indexFrom, indexTo, Constant.WHITE);
            GameLogic playerRed = new GameLogic(indexFrom, indexTo, Constant.RED);

            if(typeOfGame == 1)
                PlayerVsPlayer(playerWhite, playerRed, color);
            else if (typeOfGame == 2)
                PlayerVsComputer(playerWhite);
            else
                ComputerVsComputer();
        }

        public void PlayerVsPlayer(GameLogic playerWhite, GameLogic playerRed, string color)
        {
            if (whiteTurn && color.Equals(Constant.WHITE))
                Human(playerWhite, Constant.WHITE);
            else if (!whiteTurn && color.Equals(Constant.RED))
                Human(playerRed, Constant.RED);
        }

        public void PlayerVsComputer(GameLogic playerWhite)
        {
            if (whiteTurn)
                Human(playerWhite, Constant.WHITE);
            else
            {
                Computer(Constant.RED);
                Extend.CheckIfAnyoneAlreadyWon();
            }
        }

        public void ComputerVsComputer()
        {
            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
            while (!Extend.CheckIfAnyoneAlreadyWon())
            {
                if (whiteTurn)
                    Computer(Constant.WHITE);
                else
                    Computer(Constant.RED);
            }
            watch.Stop();
            long time = watch.ElapsedMilliseconds;
            Extend.printTimeOfBatch(time);
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
            MoveAndPoints moveAndPoints = ai.MinMax(gameBoardCopy, color, true, 3); // MinMax start
            //MoveAndPoints moveAndPoints = ai.MinMax_Alpha(gameBoardCopy, color, true, 3); // MinMax_Alpha start

            gameLogicComputer.UpdateFields(moveAndPoints);
            if (moveAndPoints.move.indexThrough != 0)
                gameLogicComputer.CheckForMoreBeating(moveAndPoints, color);
            else
            {
                gameLogicComputer.CheckIfThePawnHasReachedThePromotionField(moveAndPoints, color);
                Extend.FinishTheTurn(color);
            }
        }
    }
}
