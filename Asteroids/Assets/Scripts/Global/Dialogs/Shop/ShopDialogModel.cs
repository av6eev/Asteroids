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
        public event Action<ShipsTypes, int> OnShipBought;
        public Dictionary<ShipsTypes, ShipSpecification> ShipSpecifications { get; }
        public List<ShopCardDialogModel> Cards { get; } = new();
        
        public ShopDialogModel(Dictionary<ShipsTypes, ShipSpecification> shipSpecifications) => ShipSpecifications = shipSpecifications;

        public void Show() => OnShow?.Invoke();

        public void Hide() => OnHide?.Invoke();

        public void ChangeActiveCard(int changeDirection) => OnCardChange?.Invoke(changeDirection);

        public void BuyShip(ShipsTypes type, int price) => OnShipBought?.Invoke(type, price);

        public void Redraw(int shipId) => OnRedraw?.Invoke(shipId);
    }
}