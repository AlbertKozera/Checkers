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
        Common commonLogic = new Common();
        

        public TypeOfGame()
        {
            commonLogic.CompleteTheDictionary();
            round = true;
        }

        public void GameChooser(PictureBox fieldFrom, PictureBox fieldTo)
        {
            PlayerWhite playerWhite = new PlayerWhite(fieldFrom, fieldTo);
            PlayerRed playerRed = new PlayerRed(fieldFrom, fieldTo);
            if (round)
                Gameplay(playerWhite, Constant.WHITE, fieldTo);
            else
                Gameplay(playerRed, Constant.RED, fieldTo);
        }

        public void Gameplay(IPlayer playerLogic, string PLAYER_COLOR, PictureBox fieldTo)
        {
            forcedBeatingForPawnList = commonLogic.DoesPawnHaveAnyBeating(gameBoard, PLAYER_COLOR);
            commonLogic.MovingAPawnThatHasNoBeating(playerLogic);
            commonLogic.MovingAPawnThatHasABeating(playerLogic, Int16.Parse(fieldTo.Tag.ToString()));
        }
    }
}
