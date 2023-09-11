﻿using System;
using Game.Entities.Bullet;
using Game.Entities.Ship;
using Specifications.Base;
using UnityEngine;
using Utilities.Interfaces;

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
        public BulletView3D BulletPrefab3D;
        public BulletView2D BulletPrefab2D;
        public int Count;
        public float ReloadTime;
        public float ShootRate;
        public bool IsAutomatic;

        [Header("Movement")]
        [Range(0f, 4f)] public float Speed;

        [Header("Others")]
        public ShipView3D Prefab3D;
        public ShipView2D Prefab2D;
        public Sprite PreviewImage;
    }
}