using System;
using Specifications.Ships;

namespace Game.Ship
{
    public class ShipModel
    {
        public event Action OnMove;
        public event Action<float, float> OnTurn; 

        public ShipSpecification Specification { get; }

        public ShipModel(ShipSpecification specification)
        {
            Specification = specification;
        }
        
        public void Move()
        {
            OnMove?.Invoke();
        }

        public void Turn(float direction, float deltaTime)
        {
            OnTurn?.Invoke(direction, deltaTime);
        }
    }
}