using System;
using Game.Ship;
using Game.Ship.Bullet;
using Specifications.Base;
using UnityEngine;
using Utilities;

namespace Specifications.Ships
{
    [Serializable]
    public class ShipSpecification : ISpecification, IPurchaseable
    {
        [Header("General")]
        public int Id;
        public ShipsTypes Type;
        public string Name;
        [field: SerializeField] public int Price { get; set; }
        public int Health;

        [Header("Bullets")]
        public BulletView BulletPrefab;
        public int Count;
        public float ReloadTime;
        public float ShootRate;
        public bool IsAutomatic;

        [Header("Movement")]
        [Range(0f, 10f)] public float Speed;

        [Header("Others")]
        public ShipView Prefab;
        public Sprite PreviewImage;
    }
}