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




        /*

        public int MinMax(Dictionary<int, Field> gameBoard, string color, Boolean maximizingPlayer, int depth)
        {
            int bestValue;
            if (0 == depth)
                return evaluateGameBoard(gameBoard, color);

            int val;
            if (maximizingPlayer)
            {
                bestValue = int.MinValue;
                foreach(Move move in GetPossibleMoves(gameBoard, color))
                {
                    gameBoard = Apply(gameBoard, move);
                }


            }
        }

        public int evaluateGameBoard(Dictionary<int, Field> gameBoard, string color)
        {
            return Extend.GetNumberOfPieces(color)
        }




        public Dictionary<int, Field> Apply(Dictionary<int, Field> gameBoard, Move move)
        {
            if(move.indexThrough == 0)
            {

            }
        }



    */






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









        public void UpdateFieldFrom(Dictionary<int, Field> gameBoard, Move move)
        {
            //Extend.GetFieldByIndex(move.indexFrom).Image = new Bitmap(Properties.Resources.empty_field);
            gameBoard[move.indexFrom] = Constant.EMPTY_FIELD;
        }

        public void UpdateFieldThrough(Dictionary<int, Field> gameBoard, Move move)
        {
            //PictureBox fieldThrough = Extend.GetFieldByIndex(indexThrough);
            //fieldThrough.Image = new Bitmap(Properties.Resources.empty_field);
            gameBoard[move.indexThrough] = Constant.EMPTY_FIELD;
            //Extend.UpdateGuiCounters();
            //Extend.CheckIfAnyoneAlreadyWon();
        }

        public void UpdateFieldTo(Dictionary<int, Field> gameBoard, Move move)
        {
            //fieldTo.Image = fieldFrom.Image;
            gameBoard[move.indexTo] = gameBoard[move.indexFrom];
        }
    }
}

  