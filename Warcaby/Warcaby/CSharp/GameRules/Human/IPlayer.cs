using System;


namespace Warcaby.Service.Human
{
    public interface IPlayer
    {
        void CheckerUpdateAfterMovingAPawn();
        void CheckerUpdateAfterBeatingAPawn(int beatenPawnPosition);
        void CheckForMoreBeating();
        Boolean MovingAPawnThatHasNoBeating_Condition();
        Boolean MovingAPawnThatHasABeating_Condition();
    }
}
