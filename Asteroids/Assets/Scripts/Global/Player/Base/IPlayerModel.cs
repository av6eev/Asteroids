﻿using System;
using Utilities.Interfaces;

namespace Global.Player.Base
{
    public interface IPlayerModel
    {
        event Action<int> OnMoneyUpdated;
        event Action<IPurchaseable> OnPurchaseConfirmed; 
        int Money { get; }
        
        void SetMoneyFromSave(int money);
        void DecreaseMoney(int price);
        void ConfirmPurchase(IPurchaseable data);
        void IncreaseMoney(int gainedMoney);
    }
}