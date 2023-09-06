using Game.UI.Difficulty.Base;
using TMPro;
using UnityEngine;

namespace Game.UI.Difficulty
{
    public class DifficultyView : BaseDifficultyView
    {
        [field: SerializeField] public TextMeshProUGUI DifficultyText { get; private set; }

        public override void UpdateDifficulty(int difficulty) => DifficultyText.text = difficulty.ToString();
    }
}