using TMPro;
using UnityEngine;

namespace Game.UI.Money
{
    public class MoneyView : BaseGameUIView
    {
        [field: SerializeField] public TextMeshProUGUI CurrentMoneyText { get; private set; }
    
        public void UpdateMoneyCounter(int money)
        {
            CurrentMoneyText.text = money.ToString();
        }
    }
}