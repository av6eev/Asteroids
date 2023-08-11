using System;
using Game.Ship;
using Game.Ship.Bullet;
using Global.Pulls.ParticleSystem.Hit;
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
        public int Health;

        [Header("Bullets")]
        public BulletView BulletPrefab;
        public int Count;
        public float ReloadTime;
        public float ShootRate;
        public bool IsAutomatic;
        public HitPullView BulletHitParticleSystem;

        [Header("Movement")]
        [Range(0f, 10f)] public float Speed;

        [Header("Others")]
        public ShipView Prefab;
        public Sprite PreviewImage;
    }
}