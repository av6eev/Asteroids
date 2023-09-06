using Game.UI.Score.Base;
using TMPro;
using UnityEngine;

namespace Game.UI.Score
{
    public class ScoreView : BaseScoreView
    {
        [field: SerializeField] public TextMeshProUGUI ScoreText { get; private set; }

        public override void UpdateScore(int score) => ScoreText.text = score.ToString();
    }
}