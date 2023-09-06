using Game.UI.Base;

namespace Game.UI.Money.Base
{
    public abstract class BaseMoneyView : BaseGameUIView
    {
        public abstract void UpdateMoneyCounter(double money);
    }
}