using System;
using Game.Entities.Ship;
using Global.Dialogs.Shop.Card.Base;

namespace Global.Dialogs.Shop.Card
{
    public class ShopCardDialogModel : IShopCardDialogModel
    {
        public event Action OnShow, OnHide, OnPurchased; 
        public bool IsActive { get; private set; }
        public bool IsPurchased { get; private set; }
        public int Id { get; }
        public ShipsTypes ShipType { get; }

        public ShopCardDialogModel(ShipsTypes shipType, int shipId, bool isPurchased)
        {
            ShipType = shipType;
            IsPurchased = isPurchased;
            Id = shipId;
        }

        public void Show()
        {
            IsActive = true;
            OnShow?.Invoke();
        }

        public void Hide()
        {
            IsActive = false;
            OnHide?.Invoke();
        }

        public void SetPurchased(bool state)
        {
            IsPurchased = state;
            OnPurchased?.Invoke();
        }
    }
}