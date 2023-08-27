using System;
using UnityEngine;

namespace Utilities
{
    public class GameZoneLimits
    {
        [field: NonSerialized] public float LeftSide { get; private set; } = -75f;
        [field: NonSerialized] public float RightSide { get; private set; } = 75f;
        [field: NonSerialized] public float TopSide { get; private set; }
        [field: NonSerialized] public float BottomSide { get; private set; }

        public void UpdateTopDownBorders(float topSide, float bottomSide)
        {
            TopSide = topSide;
            BottomSide = bottomSide;
            // Debug.Log($"top: {topSide}, bot: {bottomSide}");
        }
    }
}