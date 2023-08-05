using System;
using Specifications.Base;

namespace Global.Dialogs.Shop.Card
{
    public class ShopCardDialogModel
    {
        public event Action OnShow; 
        public ISpecification ShipSpecification { get; }

        public ShopCardDialogModel(ISpecification specification)
        {
            ShipSpecification = specification;
        }

        public void Show()
        {
            OnShow?.Invoke();
        }
    }
}