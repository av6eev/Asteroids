using System;
using Specifications.Base;

namespace Global.Dialogs.Shop.Card
{
    public class ShopCardDialogModel
    {
        public event Action OnShow, OnHide; 
        public ISpecification ShipSpecification { get; }
        public bool IsActive { get; private set; }
        public int Id { get; }

        public ShopCardDialogModel(int id, ISpecification specification)
        {
            Id = id;
            ShipSpecification = specification;
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
    }
}