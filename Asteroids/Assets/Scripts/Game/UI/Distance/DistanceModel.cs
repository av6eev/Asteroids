using UnityEngine;

namespace Game.UI.Distance
{
    public class DistanceModel
    {
        public int CurrentDistance { get; private set; } = 0;

        public void UpdateDistance(int distance)
        {
            CurrentDistance = Mathf.Abs(distance);
        }
    }
}