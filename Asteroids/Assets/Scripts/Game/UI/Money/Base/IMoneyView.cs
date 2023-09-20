using Utilities.Interfaces;

namespace Game.UI.Money.Base
{
    public interface IMoneyView : IUIView
    {
        public abstract void UpdateMoneyCounter(double money);
    }
}