using System;
using System.Collections.Generic;
using System.Linq;
using Game.Entities.Bullet;
using Game.Entities.Bullet.Base;
using Global.Pulls.Base;
using Utilities;

namespace Game.Entities.Ship.Shoot
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

        public float ReloadTime { get; }
        public float ShootRate { get; }

        public bool IsReadyToShoot { get; set; }
        public bool IsReloading { get; set; }
        public bool IsAutomatic { get; }
        public int BulletDamage { get; }

        private Dictionary<BulletModel, BaseBulletView> ActiveBullets { get; set; } = new();

        public ShipShootModel(int bulletCount, float reloadTime, float shootRate, bool isAutomatic, int bulletHealth, int bulletDamage)
        {
            StartBulletCount = bulletCount;
            BulletsLeft = bulletCount;
            ReloadTime = reloadTime;
            ShootRate = shootRate;
            IsAutomatic = isAutomatic;
            BulletHealth = bulletHealth;
            BulletDamage = bulletDamage;
        }

        public void Update(float deltaTime) => OnUpdate?.Invoke(deltaTime);

        public void DestroyBullet(BulletModel model) => OnBulletDestroyed?.Invoke(model);

        public Dictionary<BulletModel, BaseBulletView> GetActiveBullets() => ActiveBullets;

        public void ResetActiveBullets() => ActiveBullets.Clear();
        
        public void AddActiveBullet(BulletModel model, BaseBulletView view3D) => ActiveBullets.Add(model, view3D);

        public void RemoveActiveBullet(BulletModel model) => ActiveBullets.Remove(model);

        public BaseBulletView GetByKey(BulletModel model) => ActiveBullets[model];

        public BulletModel GetByValue(BasePullElementView view) => !ActiveBullets.ContainsValue(view as BaseBulletView) ? null : ActiveBullets.Where(asteroid => asteroid.Value == view).Select(asteroid => asteroid.Key).FirstOrDefault();
    }
}