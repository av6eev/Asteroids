using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.EndScreen
{
    public class EndScreenView : BaseGameUIView
    {
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
    }
}