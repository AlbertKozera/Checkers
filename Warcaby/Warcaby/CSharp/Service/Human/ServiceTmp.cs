using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warcaby.Forms;


namespace Warcaby.Service.Human
{
    public class ServiceTmp
    {
        public static Dictionary<int, Field> gameBoard = new Dictionary<int, Field>();
        public static List<Tuple<int, int, int>> forcedBeatingForPawnList;
        public static Boolean round;
        CommonLogic checkerLogic = new CommonLogic();
        

        public ServiceTmp()
        {
            checkerLogic.CompleteTheDictionary();
            round = true;
        }

        public void AkaMain(PictureBox fieldFrom, PictureBox fieldTo)
        {
            if (round)
            {
                PlayerWhite playerWhite = new PlayerWhite(fieldFrom, fieldTo);
                forcedBeatingForPawnList = checkerLogic.DoesPawnHaveAnyBeating(gameBoard, Constant.WHITE);
                playerWhite.MovingAPawnThatHasNoBeating();
                playerWhite.MovingAPawnThatHasABeating();
            }
            else
            {
                PlayerRed playerRed = new PlayerRed(fieldFrom, fieldTo);
                forcedBeatingForPawnList = checkerLogic.DoesPawnHaveAnyBeating(gameBoard, Constant.RED);
                playerRed.MovingAPawnThatHasNoBeating();
                playerRed.MovingAPawnThatHasABeating();
            }
        }
    }
}
