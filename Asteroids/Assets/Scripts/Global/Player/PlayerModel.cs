using System;

namespace Global.Player
{
    public class PlayerModel
    {
        public event Action<int> OnMoneyIncreased, OnMoneyDecreased;

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

        public void IncreaseMoney(int bonus)
        {
            Money += bonus;
            OnMoneyIncreased?.Invoke(Money);
        }

        public void DecreaseMoney(int price)
        {
            Money -= price;
            OnMoneyDecreased?.Invoke(Money);
        }
    }
}