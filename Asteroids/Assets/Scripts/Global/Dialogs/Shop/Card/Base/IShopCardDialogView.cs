﻿using System;
using Global.Dialogs.Base;

namespace Global.Dialogs.Shop.Card.Base
{
    public interface IShopCardDialogView : IDialogView
    {
        event Action OnNextSelected, OnPreviousSelected, OnBought, OnSelected;

        void SwitchButtons(bool isPurchased);
        void ChangePriceText(bool isPurchased);
    }
}