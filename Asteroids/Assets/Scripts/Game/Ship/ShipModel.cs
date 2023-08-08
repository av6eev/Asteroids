using System;
using Specifications.Ships;
using Utilities;

namespace Game.Ship
{
    public class ShipModel : IUpdatable
    {
        public event Action OnShoot;
        public event Action<float> OnUpdate;

        public ShipSpecification Specification { get; }
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

        public bool IsReadyToShoot { get; set; }
        public bool IsReloading { get; set; }
        
        public ShipModel(ShipSpecification specification)
        {
            Specification = specification;
        }

        public void Shoot()
        {
            OnShoot?.Invoke();
        }

        public void Update(float deltaTime)
        {
            OnUpdate?.Invoke(deltaTime);
        }
    }
}