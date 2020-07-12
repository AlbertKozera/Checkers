using System;


namespace Warcaby.Service.Human
{
    public interface IPlayer
    {
        void CheckerUpdateAfterMovingAPawn();
        void CheckerUpdateAfterBeatingAPawn(int indexThrough);
        void CheckForMoreBeating();
        void CheckPromotion();
        Boolean MovingAPawnThatHasNoBeating_Condition();
        Boolean MovingAPawnThatHasABeating_Condition();
        Boolean CheckPromotion_Condition();
    }
}
