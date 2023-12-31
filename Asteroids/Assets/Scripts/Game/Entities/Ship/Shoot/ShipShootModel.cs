﻿using System;
using System.Collections.Generic;
using System.Linq;
using Game.Entities.Bullet.Base;
using Specifications.Ships;
using Specifications.Ships.Base;
using Utilities.Interfaces;

namespace Game.Entities.Ship.Shoot
{
    public class ShipShootModel : IUpdatable
    {
        public event Action OnShoot; 
        public event Action<float> OnUpdate;
        public event Action<IBulletModel> OnBulletDestroyed;

        private int _bulletsLeft;
        public int BulletsLeft
        {
            get => _bulletsLeft;
            set
            {
                if (value >= 0)
                {
                    _bulletsLeft = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Try to set BulletsLeft with value < 0");
                }
            }
        }
        public int StartBulletCount { get; }
        public int BulletHealth { get; }

        public float ReloadTime { get; }
        public float ShootRate { get; }

        public bool IsReadyToShoot { get; set; }
        public bool IsReloading { get; set; }
        public bool IsAutomatic { get; }
        public int BulletDamage { get; }

        private Dictionary<IBulletModel, IBulletView> ActiveBullets { get; } = new();

        public ShipShootModel(IShipSpecification specification)
        {
            StartBulletCount = specification.Count;
            BulletsLeft = specification.Count;
            ReloadTime = specification.ReloadTime;
            ShootRate = specification.ShootRate;
            IsAutomatic = specification.IsAutomatic;
            BulletHealth = specification.BulletView2D.Health;
            BulletDamage = specification.BulletView2D.Damage;
        }

        public void Shoot() => OnShoot?.Invoke();
        
        public void Update(float deltaTime) => OnUpdate?.Invoke(deltaTime);

        public void DestroyBullet(IBulletModel model) => OnBulletDestroyed?.Invoke(model);

        public Dictionary<IBulletModel, IBulletView> GetActiveBullets() => ActiveBullets;

        public void ResetActiveBullets() => ActiveBullets.Clear();
        
        public void AddActiveBullet(IBulletModel model, IBulletView view3D) => ActiveBullets.Add(model, view3D);

        public void RemoveActiveBullet(IBulletModel model) => ActiveBullets.Remove(model);

        public IBulletView GetByKey(IBulletModel model) => ActiveBullets[model];

        public IBulletModel GetByValue(IBulletView view) => !ActiveBullets.ContainsValue(view) ? null : ActiveBullets.Where(asteroid => asteroid.Value == view).Select(asteroid => asteroid.Key).FirstOrDefault();
    }
}