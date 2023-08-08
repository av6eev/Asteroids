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
            LeftSide = -60f;
            RightSide = 60f;
        }

        private void Update()
        {
            TopSide = MainCamera.transform.position.z + 25;
        }
    }
}