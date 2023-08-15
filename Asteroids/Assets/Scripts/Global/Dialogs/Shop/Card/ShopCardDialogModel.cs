using System;
using Global.Dialogs.Base;
using Specifications.Ships;

namespace Global.Dialogs.Shop.Card
{
    public class ShopCardDialogModel : ISubDialogModel
    {
        public event Action OnShow, OnHide, OnPurchased; 
        public ShipSpecification ShipSpecification { get; }
        public bool IsActive { get; private set; }
        public bool IsPurchased { get; private set; }
        public int Id { get; }

        public ShopCardDialogModel(ShipSpecification specification, bool isPurchased)
        {
            ShipSpecification = specification;
            IsPurchased = isPurchased;
            Id = specification.Id;
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