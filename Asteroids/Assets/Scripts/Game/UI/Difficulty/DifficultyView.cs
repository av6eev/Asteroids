using TMPro;
using UnityEngine;

namespace Game.UI.Difficulty
{
    public class DifficultyView : BaseGameUIView
    {
        [field: SerializeField] public TextMeshProUGUI DifficultyText { get; private set; }

        public void UpdateDifficulty(int difficulty)
        {
            DifficultyText.text = difficulty.ToString();
        }
    }
}