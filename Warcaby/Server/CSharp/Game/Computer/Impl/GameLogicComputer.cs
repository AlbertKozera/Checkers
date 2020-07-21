using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Warcaby.CSharp.Config;
using Warcaby.CSharp.Dto;
using Warcaby.CSharp.Game.Context;
using Warcaby.Forms;
using Warcaby.Service.Context;


namespace Warcaby.CSharp.Game.Computer.Impl
{
    public class GameLogicComputer
    {
        PawnComputer pawn = new PawnComputer();
        DameComputer dame = new DameComputer();

        public void CheckForMoreBeating(MoveAndPoints moveAndPoints, string color)
        {
            List<Move> forcedBeatingForPieces = GetPossibleMoves(GameService.gameBoard, color);

            bool thereAreForcedBeatings = false;
            foreach(Move move in forcedBeatingForPieces)
            {
                if (move.indexFrom.Equals(moveAndPoints.move.indexTo) && move.indexThrough != 0)
                    thereAreForcedBeatings = true;                    
            }
            if (thereAreForcedBeatings)
                Extend.RepeatTheTurn(color);
            else
            {
                CheckIfThePawnHasReachedThePromotionField(moveAndPoints, color);
                Extend.FinishTheTurn(color);
            }
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

        public void UpdateFields(MoveAndPoints moveAndPoints)
        {
            GameService.gameBoard[moveAndPoints.move.indexTo] = GameService.gameBoard[moveAndPoints.move.indexFrom];
            if (moveAndPoints.move.indexThrough != 0)
            {
                GameService.gameBoard[moveAndPoints.move.indexThrough] = Constant.EMPTY_FIELD;
            }
            GameService.gameBoard[moveAndPoints.move.indexFrom] = Constant.EMPTY_FIELD;
        }

        public void CheckIfThePawnHasReachedThePromotionField(MoveAndPoints moveAndPoints, string color)
        {
            if (Rule.ThePawnStoodInThePromotionField(moveAndPoints.move.indexTo, color))
            {
                PromoteThePawn(moveAndPoints, color);
                Extend.UpdateGuiCounters();
            }
        }

        public void PromoteThePawn(MoveAndPoints moveAndPoints, string color)
        {
            GameService.gameBoard[moveAndPoints.move.indexTo] = Extend.GetDameField(color);
            Extend.UpdateGuiCounters();
        }
    }
}
