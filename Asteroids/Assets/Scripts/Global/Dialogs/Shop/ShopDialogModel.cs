using System;
using System.Collections.Generic;
using Game.Entities.Ship;
using Global.Dialogs.Shop.Base;
using Global.Dialogs.Shop.Card.Base;

namespace Global.Dialogs.Shop
{
    public class ShopDialogModel : IShopDialogModel
    {
        public event Action OnShow, OnHide;
        public event Action<int> OnCardChange, OnRedraw;
        public event Action<ShipsTypes> OnShipBought;
        public List<IShopCardDialogModel> Cards { get; } = new();
        public IShopCardDialogModel ActiveCard => Cards.Find(item => item.IsActive);

        public void Show() => OnShow?.Invoke();

        public void Hide() => OnHide?.Invoke();

        public void ChangeActiveCard(int changeDirection) => OnCardChange?.Invoke(changeDirection);

        public void BuyShip(ShipsTypes type) => OnShipBought?.Invoke(type);

        public void Redraw(int shipId) => OnRedraw?.Invoke(shipId);
    }
}