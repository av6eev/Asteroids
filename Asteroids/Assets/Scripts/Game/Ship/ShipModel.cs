using System;
using Game.Ship.Base;
using Game.Ship.Move;
using Game.Ship.Rotate;
using Game.Ship.Shoot;
using Specifications.Ships;
using Utilities;

namespace Game.Ship
{
    public class ShipModel : IUpdatable
    {
        public event Action OnShoot, OnDamageApplied, OnActionsPaused, OnActionsContinued;
        public event Action<float> OnUpdate;
        public event Action<BaseShipView> OnViewChanged;

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

        public void ChangeView(BaseShipView newShipView) => OnViewChanged?.Invoke(newShipView);

        public void ApplyDamage()
        {
            if (!IsImmune)
            {
                OnDamageApplied?.Invoke();
            }
        }

        public void PauseActions() => OnActionsPaused?.Invoke();

        public void ContinueActions() => OnActionsContinued?.Invoke();
    }
}