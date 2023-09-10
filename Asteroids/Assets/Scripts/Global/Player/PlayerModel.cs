using System;
using Utilities.Interfaces;

namespace Global.Player
{
    public class PlayerModel
    {
        public event Action<int> OnMoneyUpdated;
        public event Action<IPurchaseable> OnPurchaseConfirmed; 

        private int _money;
        public int Money
        {
            get => _money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"Try to set negative value: {value} to player's money");
                }
                
                _money = value;
                OnMoneyUpdated?.Invoke(_money);
            }
        }

        public void SetMoneyFromSave(int money) => Money = money;

        public void DecreaseMoney(int price) => Money -= price;

        public void ConfirmPurchase(IPurchaseable data) => OnPurchaseConfirmed?.Invoke(data);
    }
}