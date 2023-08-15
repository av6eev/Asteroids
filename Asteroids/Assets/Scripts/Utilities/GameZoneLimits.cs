using System;
using Game.Ship;
using UnityEngine;

namespace Utilities
{
    public class GameZoneLimits : MonoBehaviour
    {
        [field: SerializeField] public Camera MainCamera { get; private set; }
        [field: NonSerialized] public float LeftSide { get; private set; }
        [field: NonSerialized] public float RightSide { get; private set; }
        [field: NonSerialized] public float TopSide { get; private set; }
        [field: NonSerialized] public float BottomSide { get; private set; }
        
        private void Start()
        {
            LeftSide = -75f;
            RightSide = 75f;
        }

        private void Update()
        {
            var positionZ = MainCamera.transform.position.z;
            
            TopSide = positionZ + 35;
            BottomSide = positionZ - 35;
        }
    }
}