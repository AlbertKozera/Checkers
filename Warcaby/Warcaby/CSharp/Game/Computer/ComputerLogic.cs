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

        string myColor = Constant.WHITE;


        

        public int MinMax(Dictionary<int, Field> gameBoard, string color, Boolean maximizingPlayer, int depth)
        {
            Dictionary<int, Field> gameBoardCopy = Extend.CloneGameBoard(gameBoard);
            int bestValue;
            if (0 == depth)
                return ((color == myColor) ? 1: -1) * evaluateGameBoard(gameBoard, color);

            int val;
            if (maximizingPlayer)
            {
                bestValue = int.MinValue;
                foreach(Move move in GetPossibleMoves(gameBoard, color))
                {
                    gameBoardCopy = ApplyMove(gameBoard, move);
                    val = MinMax(gameBoardCopy,  color, false, depth - 1);
                    bestValue = Math.Max(bestValue, val);
                }
                return bestValue;
            }
            else
            {
                bestValue = int.MaxValue;
                foreach (Move move in GetPossibleMoves(gameBoard, Extend.GetEnemyPlayerColor(color)))
                {
                    gameBoardCopy = ApplyMove(gameBoard, move);
                    val = MinMax(gameBoardCopy, color, true, depth - 1);
                    bestValue = Math.Min(bestValue, val);
                }
                return bestValue;
            }
        }

        public int evaluateGameBoard(Dictionary<int, Field> gameBoard, string color)
        {
            return Extend.GetNumberOfPieces(gameBoard, color) - Extend.GetNumberOfPieces(gameBoard, Extend.GetEnemyPlayerColor(color));
        }




        public Dictionary<int, Field> ApplyMove(Dictionary<int, Field> gameBoard, Move move)
        {
            if(move.indexThrough == 0)
            {
                gameBoard = UpdateFieldTo(gameBoard, move);
                gameBoard = UpdateFieldFrom(gameBoard, move);
            }
            else
            {
                gameBoard = UpdateFieldTo(gameBoard, move);
                gameBoard = UpdateFieldThrough(gameBoard, move);
                gameBoard = UpdateFieldFrom(gameBoard, move);

            }
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
            for(int i = 0; i < list.Count(); i++)
            {
                if(list[i].indexThrough != 0)
                {
                    playerHaveABeat = true;
                    break;
                }
            }
            if(playerHaveABeat)
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
            gameBoard[move.indexTo] = gameBoard[move.indexFrom];
            return gameBoard;
        }
    }
}

  