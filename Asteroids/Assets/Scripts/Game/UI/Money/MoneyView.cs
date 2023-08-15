using System;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace Game.UI.Money
{
    public class MoneyView : BaseGameUIView
    {
        [field: SerializeField] public TextMeshProUGUI CurrentMoneyText { get; private set; }
    
        public void UpdateMoneyCounter(float money)
        {
            var value = Math.Floor(money);
            CurrentMoneyText.text = value.ToString(CultureInfo.InvariantCulture);
        }
    }
}