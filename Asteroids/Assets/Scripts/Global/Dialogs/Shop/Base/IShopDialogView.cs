using System;
using Global.Dialogs.Base;
using Global.Dialogs.Shop.Card.Base;
using Specifications.Ships;

namespace Global.Dialogs.Shop.Base
{
    public interface IShopDialogView : IDialogView
    {
        event Action OnExitClicked;

        void DestroyCards();
        IShopCardDialogView InstantiateCard(ShipSpecification specification);
        void UpdateBalanceText(int money);
    }
}