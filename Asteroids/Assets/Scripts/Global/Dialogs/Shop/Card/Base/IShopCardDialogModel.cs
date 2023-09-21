using System;
using Game.Entities.Ship;
using Global.Dialogs.Base;

namespace Global.Dialogs.Shop.Card.Base
{
    public interface IShopCardDialogModel : ISubDialogModel
    {
        event Action OnPurchased; 
        bool IsActive { get; }
        bool IsPurchased { get; }
        int Id { get; }
        ShipsTypes ShipType { get; }

        void SetPurchased(bool state);
    }
}