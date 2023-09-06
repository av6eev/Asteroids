using System.Globalization;
using Game.UI.Money.Base;
using TMPro;
using UnityEngine;

namespace Game.UI.Money
{
    public class MoneyView : BaseMoneyView
    {
        [field: SerializeField] public TextMeshProUGUI CurrentMoneyText { get; private set; }
    
        public override void UpdateMoneyCounter(double money) => CurrentMoneyText.text = money.ToString(CultureInfo.InvariantCulture);
    }
}