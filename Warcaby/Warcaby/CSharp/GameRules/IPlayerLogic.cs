using System;


namespace Warcaby.Service.Human
{
    interface IPlayerLogic
    {
        void MovingAPawnThatHasNoBeating(); // powtarza sie - niech zostanie ale ---> do przemyślenia
        void MovingAPawnThatHasABeating(); // powtarza sie - niech zostanie ale ---> do przemyślenia
        void CheckerUpdateAfterMovingAPawn();
        void CheckerUpdateAfterBeatingAPawn(int beatenPawnPosition);
        void CheckForMoreBeating();
        Boolean MovingAPawnThatHasNoBeating_Condition();
        Boolean MovingAPawnThatHasABeating_Condition(); // powtarza sie - niech zostanie ale ---> do przemyślenia
    }
}
