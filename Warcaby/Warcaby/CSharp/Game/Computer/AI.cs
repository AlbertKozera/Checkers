using System;
using System.Collections.Generic;
using System.Linq;
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

        public int evaluateGameBoard(Dictionary<int, Field> gameBoard, string color) // funkcja heurycystyczna
        {
            /*
            int myCountOfPieces = Extend.GetNumberOfPieces(gameBoard, color);
            int enemyCountOfPieces = Extend.GetNumberOfPieces(gameBoard, Extend.GetEnemyPlayerColor(color));*/
            int points = 0;
            List<Move> possibleMovesList = new List<Move>();
            foreach (KeyValuePair<int, Field> pair in gameBoard)
            {
                if (pawnComputer.GetBeatingForFieldOnSpecificDiagonal(pair.Key, Extend.GetEnemyPlayerColor(color), Constant.TOP_LEFT, gameBoard) != null)
                    points = 4;
                if (pawnComputer.GetBeatingForFieldOnSpecificDiagonal(pair.Key, Extend.GetEnemyPlayerColor(color), Constant.TOP_RIGHT, gameBoard) != null)
                    points = 4;
                if (pawnComputer.GetBeatingForFieldOnSpecificDiagonal(pair.Key, Extend.GetEnemyPlayerColor(color), Constant.DOWN_LEFT, gameBoard) != null)
                    points = 4;
                if (pawnComputer.GetBeatingForFieldOnSpecificDiagonal(pair.Key, Extend.GetEnemyPlayerColor(color), Constant.DOWN_RIGHT, gameBoard) != null)
                    points = 4;

            }
            foreach (KeyValuePair<int, Field> pair in gameBoard)
            {
                possibleMovesList = pawnComputer.GetPossibleMovesForField(pair.Key, color, gameBoard);
                foreach (Move move in possibleMovesList)
                {
                    points = ruleComputer.ThePawnStoodInTheArea(move.indexTo);
                }
            }
            foreach (KeyValuePair<int, Field> pair in gameBoard)
            {
                possibleMovesList = pawnComputer.GetPossibleMovesForField(pair.Key, color, gameBoard);
                foreach (Move move in possibleMovesList)
                {
                    if (Rule.ThePawnStoodInThePromotionField(move.indexTo, color))
                        points = 5;
                    else
                        points = 0;
                }
            }
            return points;
            //return  myCountOfPieces - enemyCountOfPieces;
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

