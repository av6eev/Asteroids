using System;
using Game.UI.EndScreen.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.EndScreen
{
    public class EndScreenView : MonoBehaviour, IEndScreenView
    {
        public event Action OnMainMenuClicked;
        
        [field: SerializeField] public TextMeshProUGUI EndMoneyText { get; private set; }
        [field: SerializeField] public TextMeshProUGUI EndDistanceText { get; private set; }
        [field: SerializeField] public TextMeshProUGUI EndScoreText { get; private set; }
        [field: SerializeField] public Button MainMenuButton { get; private set; }

        public void SetData(int distance, int score, int money)
        {
            EndDistanceText.text = distance.ToString();
            EndScoreText.text = score.ToString();
            EndMoneyText.text = money.ToString();
        }
        
        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);
        
        public void InitializeButtonsSubscriptions() => MainMenuButton.onClick.AddListener(() => { OnMainMenuClicked?.Invoke(); });

        public void DisposeButtonsSubscriptions() => MainMenuButton.onClick.RemoveListener(() => { OnMainMenuClicked?.Invoke(); });
    }
}