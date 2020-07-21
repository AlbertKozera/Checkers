using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Warcaby.CSharp.Config;
using Warcaby.CSharp.Dto;
using Warcaby.CSharp.Game.Computer.Impl;
using Warcaby.CSharp.Game.Context;
using Warcaby.CSharp.Game.Context.Impl;
using Warcaby.Forms;


namespace Warcaby.CSharp.Game.Computer
{
    public class AI
    {
        GameLogicComputer gameLogicComputer = new GameLogicComputer();
        string selfColor = Constant.WHITE;
        PawnComputer pawnComputer = new PawnComputer();
        DameComputer dameComputer = new DameComputer();
        RuleComputer ruleComputer = new RuleComputer();
        Rule rule = new Rule();


        public AI(string selfColor)
        {
            this.selfColor = selfColor;
        }


        public MoveAndPoints MinMax(Dictionary<int, Field> gameBoard, string myColor, Boolean maximizingPlayer, int depth)
        {
            MoveAndPoints bestValue = new MoveAndPoints();
            if (0 == depth)
            {
                return new MoveAndPoints(((myColor == selfColor) ? 1 : -1) * evaluateGameBoard(gameBoard, myColor), bestValue.move);
            }
            if (maximizingPlayer)
            {
                bestValue.points = int.MinValue;
                var list = gameLogicComputer.GetPossibleMoves(gameBoard, myColor);
                List<int> listOfPoints = new List<int>();
                Parallel.ForEach(list, move =>
                {
                    MoveAndPoints val = new MoveAndPoints();
                    Dictionary<int, Field> gameBoardCopy = Extend.CloneGameBoard(gameBoard);
                    gameBoardCopy = ApplyMove(gameBoardCopy, move);
                    bestValue.move = move;
                    val = MinMax(gameBoardCopy, Extend.GetEnemyPlayerColor(myColor), false, depth - 1);
                    listOfPoints.Add(val.points);
                    bestValue.points = Math.Max(bestValue.points, val.points);
                    if (bestValue.points < val.points)
                        bestValue.move = val.move;
                    gameBoardCopy = RevertMove(gameBoardCopy, move);
                });
                return bestValue;
            }
            else
            {
                bestValue.points = int.MaxValue;
                var list = gameLogicComputer.GetPossibleMoves(gameBoard, myColor);
                List<int> listOfPoints = new List<int>();
                Parallel.ForEach(list, move =>
                {
                    MoveAndPoints val = new MoveAndPoints();
                    Dictionary<int, Field> gameBoardCopy = Extend.CloneGameBoard(gameBoard);
                    gameBoardCopy = ApplyMove(gameBoardCopy, move);
                    bestValue.move = move;
                    val = MinMax(gameBoardCopy, Extend.GetEnemyPlayerColor(myColor), true, depth - 1);
                    listOfPoints.Add(val.points);
                    bestValue.points = Math.Min(bestValue.points, val.points);
                    if (bestValue.points > val.points)
                        bestValue.move = val.move;
                    gameBoardCopy = RevertMove(gameBoardCopy, move);
                });
                return bestValue;
            }
        }

        public MoveAndPoints MinMaxWithoutThreads(Dictionary<int, Field> gameBoard, string myColor, Boolean maximizingPlayer, int depth)
        {
            MoveAndPoints bestValue = new MoveAndPoints();
            if (0 == depth)
            {
                return new MoveAndPoints(((myColor == selfColor) ? 1 : -1) * evaluateGameBoard(gameBoard, myColor), bestValue.move);
            }

            MoveAndPoints val = new MoveAndPoints();
            if (maximizingPlayer)
            {
                bestValue.points = int.MinValue;
                foreach (Move move in gameLogicComputer.GetPossibleMoves(gameBoard, myColor))
                {
                    gameBoard = ApplyMove(gameBoard, move);
                    bestValue.move = move;
                    val = MinMax(gameBoard, Extend.GetEnemyPlayerColor(myColor), false, depth - 1);
                    bestValue.points = Math.Max(bestValue.points, val.points);
                    gameBoard = RevertMove(gameBoard, move);
                }
                return bestValue;
            }
            else
            {
                bestValue.points = int.MaxValue;
                foreach (Move move in gameLogicComputer.GetPossibleMoves(gameBoard, myColor))
                {
                    gameBoard = ApplyMove(gameBoard, move);
                    val = MinMax(gameBoard, Extend.GetEnemyPlayerColor(myColor), true, depth - 1);
                    bestValue.points = Math.Min(bestValue.points, val.points);
                    gameBoard = RevertMove(gameBoard, move);
                }
                return bestValue;
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public int evaluateGameBoard(Dictionary<int, Field> gameBoard, string color) // funkcja heurycystyczna
        {
            int points = 0;
            int myCountOfPieces = Extend.GetNumberOfPieces(gameBoard, color);
            int enemyCountOfPieces = Extend.GetNumberOfPieces(gameBoard, Extend.GetEnemyPlayerColor(color));
            points += 40 * (myCountOfPieces - enemyCountOfPieces);

            foreach (int index in gameBoard.Keys)
            {
                if (gameBoard[index].isPawn)
                    points += ruleComputer.CheckIfThePawnHasBeat(index, Extend.GetEnemyPlayerColor(color), gameBoard);
                if (gameBoard[index].isDame)
                    points += ruleComputer.CheckIfTheDameHasBeat(index, Extend.GetEnemyPlayerColor(color), gameBoard);

                points += -1 * ruleComputer.CheckIfThePawnHasBeat(index, color, gameBoard);

                points += -1 * ruleComputer.CheckIfTheDameHasBeat(index, color, gameBoard);

                if (gameBoard[index].color.Equals(color))
                    points += ruleComputer.ThePawnStoodInTheArea(index);
            }
            return points;
        }


        public Dictionary<int, Field> ApplyMove(Dictionary<int, Field> gameBoard, Move move)
        {
            gameBoard = UpdateFieldTo(gameBoard, move);
            if (move.indexThrough != 0)
                gameBoard = UpdateFieldThrough(gameBoard, move);
            gameBoard = UpdateFieldFrom(gameBoard, move);
            return gameBoard;
        }

        public Dictionary<int, Field> RevertMove(Dictionary<int, Field> gameBoard, Move move)
        {
            gameBoard[move.indexFrom] = move.fieldFrom;
            if (move.indexThrough != 0)
            {
                gameBoard[move.indexThrough] = move.fieldThrough;
            }
            gameBoard[move.indexTo] = move.fieldTo;
            return gameBoard;
        }

        public Dictionary<int, Field> UpdateFieldFrom(Dictionary<int, Field> gameBoard, Move move)
        {
            ;
            gameBoard[move.indexFrom] = Constant.EMPTY_FIELD;
            return gameBoard;
        }

        public Dictionary<int, Field> UpdateFieldThrough(Dictionary<int, Field> gameBoard, Move move)
        {
            gameBoard[move.indexThrough] = Constant.EMPTY_FIELD;
            return gameBoard;
        }

        public Dictionary<int, Field> UpdateFieldTo(Dictionary<int, Field> gameBoard, Move move)
        {
            gameBoard[move.indexTo] = move.fieldFrom;
            return gameBoard;
        }
    }
}

