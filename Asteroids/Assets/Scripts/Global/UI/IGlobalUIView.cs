using System;
using Utilities.Interfaces;

namespace Global.UI
{
    public interface IGlobalUIView : IUIView, ISubscriptionableUI
    {
        event Action OnPlayClicked, OnShopClicked, OnHistoryClicked, OnExitClicked;

        void HideDecorationElements();
        void ShowDecorationElements();
    }
}