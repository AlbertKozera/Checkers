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
                Gameplay(playerWhiteLogic, Constant.WHITE, fieldTo);
            else
                Gameplay(playerRedLogic, Constant.RED, fieldTo);
        }

        public void Gameplay(IPlayerLogic playerLogic, string PLAYER_COLOR, PictureBox fieldTo)
        {
            forcedBeatingForPawnList = commonLogic.DoesPawnHaveAnyBeating(gameBoard, PLAYER_COLOR);
            commonLogic.MovingAPawnThatHasNoBeating(playerLogic);
            commonLogic.MovingAPawnThatHasABeating(playerLogic, Int16.Parse(fieldTo.Tag.ToString()));
        }
    }
}
