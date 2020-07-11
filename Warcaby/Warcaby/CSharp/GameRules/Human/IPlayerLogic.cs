using System;


namespace Warcaby.Service.Human
{
    public interface IPlayerLogic
    {
        void CheckerUpdateAfterMovingAPawn();
        void CheckerUpdateAfterBeatingAPawn(int beatenPawnPosition);
        void CheckForMoreBeating();
        Boolean MovingAPawnThatHasNoBeating_Condition();
        Boolean MovingAPawnThatHasABeating_Condition(); // powtarza sie - niech zostanie ale ---> do przemyślenia
    }
}
