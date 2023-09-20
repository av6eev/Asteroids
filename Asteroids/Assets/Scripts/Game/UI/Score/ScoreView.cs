using Game.UI.Score.Base;
using TMPro;
using UnityEngine;

namespace Game.UI.Score
{
    public class ScoreView : MonoBehaviour, IScoreView
    {
        [field: SerializeField] public TextMeshProUGUI ScoreText { get; private set; }

        public void UpdateScore(int score) => ScoreText.text = score.ToString();
        
        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);
    }
}