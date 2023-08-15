using Game.UI.Distance;
using Game.UI.EndScreen;
using Game.UI.Health;
using Game.UI.Money;
using Game.UI.Score;
using UnityEngine;

namespace Game.UI
{
    public class GameUIView : BaseGameUIView
    {
        [field: SerializeField] public ScoreView ScoreView { get; private set; }
        [field: SerializeField] public DistanceView DistanceView { get; private set; }
        [field: SerializeField] public HealthView HealthView { get; private set; }
        [field: SerializeField] public MoneyView MoneyView { get; private set; }
        [field: SerializeField] public EndScreenView EndScreenView { get; set; }

        public void ShowEndGameView()
        {
            MoneyView.ChangeVisibility(false);
            HealthView.ChangeVisibility(false);
            DistanceView.ChangeVisibility(false);
            ScoreView.ChangeVisibility(false);
            EndScreenView.ChangeVisibility(false);
        }
    }
}