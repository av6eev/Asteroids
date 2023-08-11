using System;
using Unity.VisualScripting;
using Utilities;

namespace Game.Ship.Shoot
{
    public class ShipShootModel : IUpdatable
    {
        public event Action<float> OnUpdate;

        private int _shotsLeft;
        public int ShotsLeft
        {
            get => _shotsLeft;
            set
            {
                if (value >= 0)
                {
                    _shotsLeft = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Try to set ShotsLeft with value < 0");
                }
            }
        }
        public int StartBulletCount { get; }

        public float ReloadTime { get; }
        public float ShotRate { get; }
        public float BulletSpeed { get; }

        public bool IsReadyToShoot { get; set; }
        public bool IsReloading { get; set; }
        public bool IsAutomatic { get; }

        public ShipShootModel(int shotCount, float reloadTime, float shotRate, bool isAutomatic, float bulletSpeed)
        {
            StartBulletCount = shotCount;
            ShotsLeft = shotCount;
            ReloadTime = reloadTime;
            ShotRate = shotRate;
            IsAutomatic = isAutomatic;
            BulletSpeed = bulletSpeed;
        }

        public void Update(float deltaTime)
        {
            OnUpdate?.Invoke(deltaTime);
        }
    }
}