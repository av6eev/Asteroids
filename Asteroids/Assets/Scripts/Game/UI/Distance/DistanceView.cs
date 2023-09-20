using Game.UI.Distance.Base;
using TMPro;
using UnityEngine;

namespace Game.UI.Distance
{
    public class DistanceView : MonoBehaviour, IDistanceView
    {
        [field: SerializeField] public TextMeshProUGUI DistanceText { get; private set; }

        public void UpdateDistance(int value) => DistanceText.text = value.ToString();
        
        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);
    }
}