using System;
using Global.Dialogs.Base;
using Global.Dialogs.Shop.Card.Base;
using Specifications.Ships;
using Specifications.Ships.Base;

namespace Global.Dialogs.Shop.Base
{
    public interface IShopDialogView : IDialogView
    {
        event Action OnExitClicked;

        void DestroyCards();
        IShopCardDialogView InstantiateCard(IShipSpecification specification);
        void UpdateBalanceText(int money);
    }
}