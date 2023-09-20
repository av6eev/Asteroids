using System;
using Global.Dialogs.Base;
using Global.Dialogs.Shop.Card;
using Specifications.Ships;

namespace Global.Dialogs.Shop.Base
{
    public interface IShopDialogView : IDialogView
    {
        event Action OnExitClicked;

        void DestroyCards();
        ShopCardDialogView InstantiateCard(ShipSpecification specification);
        void UpdateBalanceText(int money);
    }
}