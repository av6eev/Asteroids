using System;
using Utilities;

namespace Global.Player
{
    public class PlayerModel
    {
        public event Action<int> OnMoneyIncreased, OnMoneyDecreased, OnMoneySet;
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
            }
        }

        public void SetMoneyFromSave(int money)
        {
            Money = money;
            OnMoneySet?.Invoke(Money);
        }

        public void IncreaseMoney(int bonus)
        {
            Money += bonus;
            OnMoneyIncreased?.Invoke(bonus);
        }

        public void DecreaseMoney(int price)
        {
            Money -= price;
            OnMoneyDecreased?.Invoke(Money);
        }

        public void ConfirmPurchase(IPurchaseable data)
        {
            OnPurchaseConfirmed?.Invoke(data);
        }
    }
}