using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warcaby.CSharp.Game.Context;
using Warcaby.Forms;
using Warcaby.Service.Context;

namespace Warcaby.CSharp.Game.Computer
{
    public class ComputerLogic
    {
        PawnComputer pawn = new PawnComputer();
        DameComputer dame = new DameComputer();
        string enemyColor = Constant.WHITE;
        Dictionary<int, Move> slownik = new Dictionary<int, Move>();








        public MoveAndPoints MinMax(Dictionary<int, Field> gameBoard, string myColor, Boolean maximizingPlayer, int depth)
        {
            MoveAndPoints bestValue = new MoveAndPoints();
            if (0 == depth)
            {
                return new MoveAndPoints(((myColor == enemyColor) ? 1 : -1) * evaluateGameBoard(gameBoard, myColor), bestValue.move);
            }
                
            MoveAndPoints val = new MoveAndPoints();
            if (maximizingPlayer)
            {
                bestValue.points = int.MinValue;
                foreach (Move move in GetPossibleMoves(gameBoard, myColor))
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
                foreach (Move move in GetPossibleMoves(gameBoard, myColor))
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
            return Extend.GetNumberOfPieces(gameBoard, color) - Extend.GetNumberOfPieces(gameBoard, Extend.GetEnemyPlayerColor(color));
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
























        public List<Move> GetPossibleMoves(Dictionary<int, Field> gameBoard, string color)
        {
            List<Move> list = new List<Move>();
            bool playerHaveABeat = false;



            foreach (int i in gameBoard.Keys)
            {
                if (gameBoard[i].isPawn && gameBoard[i].color.Equals(color))
                {
                    list.AddRange(pawn.GetPossibleMovesForField(i, color, gameBoard));
                }
                else if (gameBoard[i].isDame && gameBoard[i].color.Equals(color))
                {
                    list.AddRange(dame.GetPossibleMovesForField(i, color, gameBoard));
                }
            }
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i].indexThrough != 0)
                {
                    playerHaveABeat = true;
                    break;
                }
            }
            if (playerHaveABeat)
            {
                list.RemoveAll(m => m.indexThrough == 0);
            }





            return list;
        }










        public Dictionary<int, Field> UpdateFieldFrom(Dictionary<int, Field> gameBoard, Move move)
        {
            //Extend.GetFieldByIndex(move.indexFrom).Image = new Bitmap(Properties.Resources.empty_field);
            gameBoard[move.indexFrom] = Constant.EMPTY_FIELD;
            return gameBoard;
        }

        public Dictionary<int, Field> UpdateFieldThrough(Dictionary<int, Field> gameBoard, Move move)
        {
            //PictureBox fieldThrough = Extend.GetFieldByIndex(indexThrough);
            //fieldThrough.Image = new Bitmap(Properties.Resources.empty_field);
            gameBoard[move.indexThrough] = Constant.EMPTY_FIELD;
            return gameBoard;
            //Extend.UpdateGuiCounters();
            //Extend.CheckIfAnyoneAlreadyWon();
        }

        public Dictionary<int, Field> UpdateFieldTo(Dictionary<int, Field> gameBoard, Move move)
        {
            //fieldTo.Image = fieldFrom.Image;
            gameBoard[move.indexTo] = move.fieldFrom;
            return gameBoard;
        }
    }
}

