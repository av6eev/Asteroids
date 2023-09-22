using System;
using Game.Entities.Bullet;
using Game.Entities.Bullet.Base;
using Game.Entities.Ship;
using Game.Entities.Ship.Base;
using Specifications.Ships.Base;
using UnityEngine;

namespace Specifications.Ships
{
    [Serializable]
    public class ShipSpecification : IShipSpecification
    {
        [field: Header("General")]
        [field: SerializeField] public int Id { get; private set; }
        [field: SerializeField] public ShipsTypes Type { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Price { get; private set; }
        [field: SerializeField] public int Health { get; private set; }

        [field: Header("Bullets")]
        [field: SerializeField] public BulletView3D BulletPrefab3D { get; private set; }
        [field: SerializeField] public BulletView2D BulletPrefab2D { get; private set; }
        [field: SerializeField] public int Count { get; private set; }
        [field: SerializeField] public float ReloadTime { get; private set; }
        [field: SerializeField] public float ShootRate { get; private set; }
        [field: SerializeField] public bool IsAutomatic { get; private set; }

        [field: Header("Movement")]
        [field: SerializeField] [field: Range(0f, 4f)] public float Speed { get; private set; }

        [field: Header("Others")]
        [field: SerializeField] public ShipView3D Prefab3D { get; private set; }
        [field: SerializeField] public ShipView2D Prefab2D { get; private set; }

        public IBulletView BulletView3D => BulletPrefab3D;
        public IBulletView BulletView2D => BulletPrefab2D;
        public IShipView ShipView2D => Prefab2D;
        public IShipView ShipView3D => Prefab3D;
    }
}