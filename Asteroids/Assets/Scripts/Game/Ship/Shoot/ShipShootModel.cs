using System;
using System.Collections.Generic;
using System.Linq;
using Game.Ship.Bullet;
using Global.Pulls.Base;
using Utilities;

namespace Game.Ship.Shoot
{
    public class ShipShootModel : IUpdatable
    {
        public event Action<float> OnUpdate;
        public event Action<BulletModel> OnBulletDestroyed;

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

        public float BulletSpeed { get; }
        public float ReloadTime { get; }
        public float ShootRate { get; }

        public bool IsReadyToShoot { get; set; }
        public bool IsReloading { get; set; }
        public bool IsAutomatic { get; }
        public int BulletDamage { get; }

        private readonly Dictionary<BulletModel, BulletView> _activeBullets = new();

        public ShipShootModel(int bulletCount, float reloadTime, float shootRate, bool isAutomatic, float bulletSpeed, int bulletHealth, int bulletDamage)
        {
            StartBulletCount = bulletCount;
            BulletsLeft = bulletCount;
            ReloadTime = reloadTime;
            ShootRate = shootRate;
            IsAutomatic = isAutomatic;
            BulletSpeed = bulletSpeed;
            BulletHealth = bulletHealth;
            BulletDamage = bulletDamage;
        }

        public void Update(float deltaTime)
        {
            OnUpdate?.Invoke(deltaTime);
        }

        public void DestroyBullet(BulletModel model)
        {
            OnBulletDestroyed?.Invoke(model);
        }

        public void AddActiveBullet(BulletModel model, BulletView view)
        {
            _activeBullets.Add(model, view);
        }
        
        public Dictionary<BulletModel, BulletView> GetActiveBullets()
        {
            return _activeBullets;
        }

        public BulletModel GetByValue(BasePullElementView view)
        {
            if (!_activeBullets.ContainsValue(view as BulletView)) return null;

            return _activeBullets.Where(asteroid => asteroid.Value == view).Select(asteroid => asteroid.Key).FirstOrDefault();
        }
    }
}