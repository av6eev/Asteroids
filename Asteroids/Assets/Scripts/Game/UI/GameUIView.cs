using Game.UI.Difficulty;
using Game.UI.Distance;
using Game.UI.EndScreen;
using Game.UI.Health;
using Game.UI.Money;
using Game.UI.Score;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class GameUIView : BaseGameUIView
    {
        [field: SerializeField] public ScoreView ScoreView { get; private set; }
        [field: SerializeField] public DistanceView DistanceView { get; private set; }
        [field: SerializeField] public HealthView HealthView { get; private set; }
        [field: SerializeField] public MoneyView MoneyView { get; private set; }
        [field: SerializeField] public DifficultyView DifficultyView { get; private set; }
        [field: SerializeField] public EndScreenView EndScreenView { get; private set; }
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