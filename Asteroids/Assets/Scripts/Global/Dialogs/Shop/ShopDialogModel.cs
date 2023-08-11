using System;
using System.Collections.Generic;
using Global.Dialogs.Base;
using Global.Dialogs.Shop.Card;
using Specifications.Ships;

namespace Global.Dialogs.Shop
{
    public class ShopDialogModel : IGlobalDialogModel
    {
        public event Action OnShow, OnHide;
        public event Action<int> OnCardChange; 
        public Dictionary<int, ShipSpecification> ShipSpecifications { get; }
        public List<ShopCardDialogModel> Cards { get; } = new();
        
        public ShopDialogModel(Dictionary<int, ShipSpecification> shipSpecifications)
        {
            ShipSpecifications = shipSpecifications;
        }
        
        public void Show()
        {
            OnShow?.Invoke();            
        }

        public void Hide()
        {
            OnHide?.Invoke();
        }

        public void ChangeActiveCard(int changeDirection)
        {
            OnCardChange?.Invoke(changeDirection);
        }
    }
}