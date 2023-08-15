using TMPro;
using UnityEngine;

namespace Game.UI.Score
{
    public class ScoreView : BaseGameUIView
    {
        [field: SerializeField] public TextMeshProUGUI ScoreText { get; private set; }

        public void UpdateScore(int score)
        {
            ScoreText.text = score.ToString();
        }
    }
}