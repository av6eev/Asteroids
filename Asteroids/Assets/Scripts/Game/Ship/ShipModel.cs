﻿using System;
using Game.Ship.Move;
using Game.Ship.Rotate;
using Game.Ship.Shoot;
using Specifications.Ships;
using Utilities;

namespace Game.Ship
{
    public class ShipModel : IUpdatable
    {
        public event Action OnShoot, OnDamageApplied;
        public event Action<float> OnUpdate;

        public ShipMoveModel MoveModel { get; set; }
        public ShipShootModel ShootModel { get; set; }
        public ShipRotateModel RotateModel { get; set; }
        public ShipSpecification Specification { get; }
        
        private int _health;
        public int Health
        {
            get => _health;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"Try to set negative value: {value} to ship");
                }
                
                _health = value;
            }
        }
        public bool IsImmune { get; set; }

        public ShipModel(ShipSpecification specification)
        {
            Specification = specification;
            Health = specification.Health;
        }

        public void Shoot() => OnShoot?.Invoke();

        public void Update(float deltaTime) => OnUpdate?.Invoke(deltaTime);

        public void ApplyDamage()
        {
            if (!IsImmune)
            {
                OnDamageApplied?.Invoke();
            }
        }
    }
}