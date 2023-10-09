using System;
using System.Collections.Generic;
using Game.Entities.Ship;
using Global.Dialogs.Base;
using Global.Dialogs.Shop.Card.Base;

namespace Global.Dialogs.Shop.Base
{
    public interface IShopDialogModel : IGlobalDialogModel
    {
        event Action<int> OnCardChange, OnRedraw;
        event Action<ShipsTypes> OnShipBought;
        
        public List<IShopCardDialogModel> Cards { get; }
        public IShopCardDialogModel ActiveCard => Cards.Find(item => item.IsActive);
        
        public void ChangeActiveCard(int changeDirection);

        public void BuyShip(ShipsTypes type);

        public void Redraw(int shipId);
    }
}