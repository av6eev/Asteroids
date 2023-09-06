using Game.UI.Base;
using Game.UI.Difficulty.Base;
using Game.UI.Distance.Base;
using Game.UI.EndScreen.Base;
using Game.UI.Health.Base;
using Game.UI.Money.Base;
using Game.UI.Score.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class GameUIView : BaseGameUIView
    {
        [field: SerializeField] public BaseScoreView ScoreView { get; private set; }
        [field: SerializeField] public BaseDistanceView DistanceView { get; private set; }
        [field: SerializeField] public BaseHealthView HealthView { get; private set; }
        [field: SerializeField] public BaseMoneyView MoneyView { get; private set; }
        [field: SerializeField] public BaseDifficultyView DifficultyView { get; private set; }
        [field: SerializeField] public BaseEndScreenView EndScreenView { get; private set; }
        [field: SerializeField] public Button ChangeCameraButton { get; private set; }

        public void HideElementsAfterEnd()
        {
            MoneyView.ChangeVisibility(false);
            HealthView.ChangeVisibility(false);
            DistanceView.ChangeVisibility(false);
            ScoreView.ChangeVisibility(false);
            DifficultyView.ChangeVisibility(false);
            ChangeCameraButton.gameObject.SetActive(false);
        }
    }
}