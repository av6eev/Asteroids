using TMPro;
using UnityEngine;

namespace Game.Score
{
    public class ScoreView : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI ScoreText { get; private set; }

        public void UpdateScore(int score)
        {
            ScoreText.text = score.ToString();
        }
    }
}