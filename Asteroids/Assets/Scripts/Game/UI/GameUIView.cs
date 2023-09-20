using System;
using Game.UI.Base;
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
    public class GameUIView : MonoBehaviour, IGameUIView
    {
        public event Action OnCameraChanged;
        
        [field: SerializeField] public ScoreView ScoreView { get; private set; }
        [field: SerializeField] public DistanceView DistanceView { get; private set; }
        [field: SerializeField] public HealthView HealthView { get; private set; }
        [field: SerializeField] public MoneyView MoneyView { get; private set; }
        [field: SerializeField] public DifficultyView DifficultyView { get; private set; }
        [field: SerializeField] public EndScreenView EndScreenView { get; private set; }
        [field: SerializeField] public Button ChangeCameraButton { get; private set; }

        private void Start() => EndScreenView.gameObject.SetActive(false);

        public void InitializeButtonsSubscriptions() => ChangeCameraButton.onClick.AddListener(() => { OnCameraChanged?.Invoke(); });

        public void DisposeButtonsSubscriptions() => ChangeCameraButton.onClick.RemoveListener(() => { OnCameraChanged?.Invoke(); });

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);

        public void HideElementsAfterEnd()
        {
            MoneyView.Hide();
            HealthView.Hide();
            DistanceView.Hide();
            ScoreView.Hide();
            DifficultyView.Hide();
            ChangeCameraButton.gameObject.SetActive(false);
        }
    }
}