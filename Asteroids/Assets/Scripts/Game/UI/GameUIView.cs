using Game.Distance;
using Game.Score;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class GameUIView : MonoBehaviour
    {
        [field: SerializeField] public Image HealthBar { get; private set; }
        [field: SerializeField] public ScoreView ScoreView { get; private set; }
        [field: SerializeField] public DistanceView DistanceView { get; private set; }

        public void UpdateHealthBar()
        {
            HealthBar.fillAmount -= .33f;
        }

        public void SetStartedHealth(int maxHealth)
        {
            HealthBar.fillAmount = maxHealth;
        }
    }
}