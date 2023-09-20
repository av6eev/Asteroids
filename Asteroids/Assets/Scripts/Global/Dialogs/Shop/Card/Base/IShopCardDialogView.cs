using System;
using Global.Dialogs.Base;
using Specifications.Ships;

namespace Global.Dialogs.Shop.Card.Base
{
    public interface IShopCardDialogView : IDialogView
    {
        event Action OnNextSelected, OnPreviousSelected, OnBought, OnSelected;

        void SetupCard(ShipSpecification specification);
        void SwitchButtons(bool isPurchased);
        void ChangePriceText(bool isPurchased);
    }
}