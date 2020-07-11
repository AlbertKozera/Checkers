using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warcaby.Forms;

namespace Warcaby.Service
{
    public class PlayerWhite
    {


        public void MovingAPawnThatHasNoBeating(List<Tuple<int, int, int>> forcedBeatingForPawnList)
        {
            if (MovingPawnThatHasNoBeating_Condition(forcedBeatingForPawnList))
            {
                CheckerUpdateAfterMovingAPawn();
            }
        }

        public void MovingAPawnThatHasABeating(List<Tuple<int, int, int>> forcedBeatingForPawnList)
        {
            if (MovingAPawnThatHasABeating_Condition(forcedBeatingForPawnList))
            {
                forcedBeatingForPawnList.ForEach(delegate (Tuple<int, int, int> forcedBeatingForPawnTuple)
                {
                    if (forcedBeatingForPawnTuple.Item2 == indexTo) //sprawdzenie czy biały pionek zbił przeciwny pionek - przymusowe bicie
                    {
                        CheckerUpdateAfterBeatingAPawn();

                    }
                });

                CheckForMoreBeating();

                forcedBeatingForPawnList.Clear();
            }
        }























        public Boolean MovingAPawnThatHasNoBeating_Condition(List<Tuple<int, int, int>> forcedBeatingForPawnList)
        {
            /*
            return Extend.IsNullOrEmpty(forcedBeatingForPawnList)
                && (indexTo == indexFrom + 7 || indexTo == indexFrom + 9);*/
        }




        public void CheckForMoreBeating()
        {
            /*            forcedBeatingForPawnList = checkerLogic.DoesPawnHaveAnyBeating(gameBoard, "white"); //Tą funkcję trzeba wywołać dla jednego pola
                        if (Extend.IsNullOrEmpty(forcedBeatingForPawnList)) //jeśli nie ma bicia
                            round = false;
                        else
                            round = true;*/
        }



        public Boolean MovingAPawnThatHasABeating_Condition(List<Tuple<int, int, int>> forcedBeatingForPawnList)
        {
            /*
            return (indexTo == indexFrom - 14 || indexTo == indexFrom - 18
                || indexTo == indexFrom + 14 || indexTo == indexFrom + 18);*/
        }














        public void CheckerUpdateAfterMovingAPawn()
        {
            // fieldFrom.Image = new Bitmap(Properties.Resources.empty_field);
            // gameBoard[indexFrom] = Constant.EMPTY_FIELD;

            // fieldTo.Image = fieldFrom.Image;
            // gameBoard[indexTo] = Constant.PAWN_WHITE;
        }

        public void CheckerUpdateAfterBeatingAPawn()
        {
            // fieldFrom.Image = new Bitmap(Properties.Resources.empty_field);
            // gameBoard[indexFrom] = Constant.EMPTY_FIELD;

            // beatenPawnField.Image = new Bitmap(Properties.Resources.empty_field);
            //  gameBoard[beatenPawnPosition] = Constant.EMPTY_FIELD;

            // fieldTo.Image = fieldFrom.Image;
            // gameBoard[indexTo] = Constant.PAWN_WHITE;


        }







    }
}
