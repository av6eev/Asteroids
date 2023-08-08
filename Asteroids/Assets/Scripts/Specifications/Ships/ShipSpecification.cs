﻿using System;
using Game.Ship;
using Game.Ship.Shots.Shot;
using Specifications.Base;
using UnityEngine;

namespace Specifications.Ships
{
    [Serializable]
    public class ShipSpecification : ISpecification
    {
        [Header("General")]
        public int Id;
        public string Name;
        public int Price;

        [Header("Shots")]
        public ShotView ShotPrefab;
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