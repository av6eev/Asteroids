using System;
using Game.UI.Base;
using Game.UI.Difficulty;
using Game.UI.Difficulty.Base;
using Game.UI.Distance;
using Game.UI.Distance.Base;
using Game.UI.EndScreen;
using Game.UI.EndScreen.Base;
using Game.UI.Health;
using Game.UI.Health.Base;
using Game.UI.Money;
using Game.UI.Money.Base;
using Game.UI.Score;
using Game.UI.Score.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class GameUIView : MonoBehaviour, IGameUIView
    {
        public event Action OnCameraChanged;
        
        [field: SerializeField] public ScoreView ScoreViewGo { get; private set; }
        [field: SerializeField] public DistanceView DistanceViewGo { get; private set; }
        [field: SerializeField] public HealthView HealthViewGo { get; private set; }
        [field: SerializeField] public MoneyView MoneyViewGo { get; private set; }
        [field: SerializeField] public DifficultyView DifficultyViewGo { get; private set; }
        [field: SerializeField] public EndScreenView EndScreenViewGo { get; private set; }
        [field: SerializeField] public Button ChangeCameraButton { get; private set; }

        public IScoreView ScoreView => ScoreViewGo;
        public IDistanceView DistanceView => DistanceViewGo;
        public IHealthView HealthView => HealthViewGo;
        public IMoneyView MoneyView => MoneyViewGo;
        public IDifficultyView DifficultyView => DifficultyViewGo;
        public IEndScreenView EndScreenView => EndScreenViewGo;
        
        private void Start() => EndScreenViewGo.gameObject.SetActive(false);

        public void InitializeButtonsSubscriptions() => ChangeCameraButton.onClick.AddListener(() => { OnCameraChanged?.Invoke(); });

        public void DisposeButtonsSubscriptions() => ChangeCameraButton.onClick.RemoveListener(() => { OnCameraChanged?.Invoke(); });

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);

        public void HideElementsAfterEnd()
        {
            MoneyViewGo.Hide();
            HealthViewGo.Hide();
            DistanceViewGo.Hide();
            ScoreViewGo.Hide();
            DifficultyViewGo.Hide();
            ChangeCameraButton.gameObject.SetActive(false);
        }
    }
}