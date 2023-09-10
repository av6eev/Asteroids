using System;
using System.Collections.Generic;
using Game.Entities.Ship;
using Global.Dialogs.Base;
using Global.Dialogs.Shop.Card;
using Specifications.Ships;

namespace Global.Dialogs.Shop
{
    public class ShopDialogModel : IGlobalDialogModel
    {
        public event Action OnShow, OnHide;
        public event Action<int> OnCardChange, OnRedraw;
        public event Action<ShipSpecification> OnShipBought;
        public Dictionary<ShipsTypes, ShipSpecification> ShipSpecifications { get; }
        public List<ShopCardDialogModel> Cards { get; } = new();
        public ShopCardDialogModel ActiveCard => Cards.Find(item => item.IsActive);

        public ShopDialogModel(Dictionary<ShipsTypes, ShipSpecification> shipSpecifications) => ShipSpecifications = shipSpecifications;

        public void Show() => OnShow?.Invoke();

        public void Hide() => OnHide?.Invoke();

        public void ChangeActiveCard(int changeDirection) => OnCardChange?.Invoke(changeDirection);

        public void BuyShip(ShipSpecification specification) => OnShipBought?.Invoke(specification);

        public void Redraw(int shipId) => OnRedraw?.Invoke(shipId);
    }
}