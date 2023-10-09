using Game.UI.Difficulty.Base;
using TMPro;
using UnityEngine;

namespace Game.UI.Difficulty
{
    public class DifficultyView : MonoBehaviour, IDifficultyView
    {
        [field: SerializeField] public TextMeshProUGUI DifficultyText { get; private set; }

        public void UpdateDifficulty(int difficulty) => DifficultyText.text = difficulty.ToString();
        
        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);
    }
}