using TMPro;
using UnityEngine;

namespace Game.UI.Distance
{
    public class DistanceView : BaseGameUIView
    {
        [field: SerializeField] public TextMeshProUGUI DistanceText { get; private set; }

        public void UpdateDistance(int value) => DistanceText.text = value.ToString();
    }
}