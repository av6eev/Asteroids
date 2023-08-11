using System;
using Game.Ship.Move;
using Game.Ship.Shoot;
using Specifications.Ships;
using Utilities;

namespace Game.Ship
{
    public class ShipModel : IUpdatable
    {
        public event Action OnShoot;
        public event Action<float> OnUpdate;

        public ShipMoveModel MoveModel { get; set; }
        public ShipShootModel ShootModel { get; set; }
        public ShipSpecification Specification { get; }
        
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