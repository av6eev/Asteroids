using System.Globalization;
using TMPro;
using UnityEngine;

namespace Game.UI.Money
{
    public class MoneyView : BaseGameUIView
    {
        [field: SerializeField] public TextMeshProUGUI CurrentMoneyText { get; private set; }
    
        public void UpdateMoneyCounter(double money) => CurrentMoneyText.text = money.ToString(CultureInfo.InvariantCulture);
    }
}