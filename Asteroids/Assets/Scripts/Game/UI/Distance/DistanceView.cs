using Game.UI.Distance.Base;
using TMPro;
using UnityEngine;

namespace Game.UI.Distance
{
    public class DistanceView : BaseDistanceView
    {
        [field: SerializeField] public TextMeshProUGUI DistanceText { get; private set; }

        public override void UpdateDistance(int value) => DistanceText.text = value.ToString();
    }
}