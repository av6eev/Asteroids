using System.Globalization;
using Game.UI.Money.Base;
using TMPro;
using UnityEngine;

namespace Game.UI.Money
{
    public class MoneyView : MonoBehaviour, IMoneyView
    {
        [field: SerializeField] public TextMeshProUGUI CurrentMoneyText { get; private set; }
    
        public void UpdateMoneyCounter(double money) => CurrentMoneyText.text = money.ToString(CultureInfo.InvariantCulture);
        
        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);
    }
}