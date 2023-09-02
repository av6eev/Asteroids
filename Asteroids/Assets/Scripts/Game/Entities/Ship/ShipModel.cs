using System;
using Game.Entities.Base;
using Game.Entities.Ship.Base;
using Game.Entities.Ship.Move;
using Game.Entities.Ship.Rotate;
using Game.Entities.Ship.Shoot;
using Specifications.Ships;
using Utilities.Interfaces;

namespace Game.Entities.Ship
{
    public class ShipModel : BaseEntity, IUpdatable
    {
        public event Action OnShoot, OnDamageApplied, OnActionsPaused, OnActionsContinued, OnDestroy;
        public event Action<float> OnUpdate;
        public event Action<BaseShipView> OnViewChanged;

        public ShipMoveModel MoveModel { get; set; }
        public ShipShootModel ShootModel { get; set; }
        public ShipRotateModel RotateModel { get; set; }
        public ShipSpecification Specification { get; }

        public bool IsImmune { get; private set; }

        public ShipModel(ShipSpecification specification)
        {
            Specification = specification;
            Health = specification.Health;
        }

        public void Shoot() => OnShoot?.Invoke();

        public void Update(float deltaTime) => OnUpdate?.Invoke(deltaTime);

        public void ChangeView(BaseShipView newShipView) => OnViewChanged?.Invoke(newShipView);

        public void PauseActions() => OnActionsPaused?.Invoke();

        public void ContinueActions() => OnActionsContinued?.Invoke();

        public void UpdateImmuneState(bool state) => IsImmune = state;

        public override void ApplyDamage(int damage)
        {
            if (!IsImmune)
            {
                Health -= damage;
                OnDamageApplied?.Invoke();
                
                if (Health <= 0)
                {
                    OnDestroy?.Invoke();
                }
            }
        }
    }
}