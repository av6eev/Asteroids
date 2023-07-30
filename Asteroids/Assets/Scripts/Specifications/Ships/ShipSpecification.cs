using System;
using Game.Ship;
using Specifications.Base;
using UnityEngine;

namespace Specifications.Ships
{
    [Serializable]
    public class ShipSpecification : ISpecification
    {
        public int Id;
        public string Name;
        [Range(0f, 10f)] public float Speed;
        public ShipView Prefab;
    }
}