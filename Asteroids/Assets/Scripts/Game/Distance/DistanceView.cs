using System.Globalization;
using TMPro;
using UnityEngine;

namespace Game.Distance
{
    public class DistanceView : MonoBehaviour
    {
        [field: SerializeField] public TextMeshProUGUI DistanceText { get; private set; }
        
        public void UpdateDistance(float shipPosition)
        {
            DistanceText.text = shipPosition.ToString(CultureInfo.InvariantCulture);
        }
    }
}