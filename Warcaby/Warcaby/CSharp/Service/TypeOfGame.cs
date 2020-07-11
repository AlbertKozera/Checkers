using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warcaby.Forms;


namespace Warcaby.Service.Human
{
    public class TypeOfGame
    {
        public static Dictionary<int, Field> gameBoard = new Dictionary<int, Field>();
        public static List<Tuple<int, int, int>> forcedBeatingForPawnList;
        public static Boolean round;
        CommonLogic commonLogic = new CommonLogic();
        

        public TypeOfGame()
        {
            commonLogic.CompleteTheDictionary();
            round = true;
        }

        public void GameChooser(PictureBox fieldFrom, PictureBox fieldTo)
        {
            PlayerWhiteLogic playerWhiteLogic = new PlayerWhiteLogic(fieldFrom, fieldTo);
            PlayerRedLogic playerRedLogic = new PlayerRedLogic(fieldFrom, fieldTo);
            if (round)
                Gameplay(playerWhiteLogic, Constant.WHITE);
            else
                Gameplay(playerRedLogic, Constant.RED);
        }

        public void Gameplay(IPlayerLogic playerLogic, string PLAYER_COLOR)
        {
            forcedBeatingForPawnList = commonLogic.DoesPawnHaveAnyBeating(gameBoard, PLAYER_COLOR);
            playerLogic.MovingAPawnThatHasNoBeating();
            playerLogic.MovingAPawnThatHasABeating();
        }
    }
}
