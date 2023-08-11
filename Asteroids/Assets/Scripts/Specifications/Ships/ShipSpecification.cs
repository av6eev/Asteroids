using System;
using Game.Ship;
using Game.Ship.Shots;
using Specifications.Base;
using UnityEngine;
using UnityEngine.Serialization;

namespace Specifications.Ships
{
    [Serializable]
    public class ShipSpecification : ISpecification
    {
        [Header("General")]
        public int Id;
        public string Name;
        public int Price;

        [FormerlySerializedAs("ShotPrefab")] [Header("Shots")]
        public BulletView BulletPrefab;
        public int Count;
        public float ReloadTime;
        public float ShotRate;
        public bool IsAutomatic;

        [Header("Movement")]
        [Range(0f, 10f)] public float Speed;

        [Header("Others")]
        public ShipView Prefab;
        public Sprite PreviewImage;
    }
}