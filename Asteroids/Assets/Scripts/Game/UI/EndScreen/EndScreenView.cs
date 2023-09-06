using Game.UI.EndScreen.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.EndScreen
{
    public class EndScreenView : BaseEndScreenView
    {
        [field: SerializeField] public TextMeshProUGUI EndMoneyText { get; private set; }
        [field: SerializeField] public TextMeshProUGUI EndDistanceText { get; private set; }
        [field: SerializeField] public TextMeshProUGUI EndScoreText { get; private set; }
        [field: SerializeField] public override Button MainMenuButton { get; protected set; }

        public override void SetData(int distance, int score, int money)
        {
            EndDistanceText.text = distance.ToString();
            EndScoreText.text = score.ToString();
            EndMoneyText.text = money.ToString();
        }
    }
}