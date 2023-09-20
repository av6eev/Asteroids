using System;
using Utilities.Interfaces;

namespace Game.UI.EndScreen.Base
{
    public interface IEndScreenView : IUIView, ISubscriptionableUI
    {
        event Action OnMainMenuClicked;
        
        public void SetData(int distance, int score, int money);
    }
}