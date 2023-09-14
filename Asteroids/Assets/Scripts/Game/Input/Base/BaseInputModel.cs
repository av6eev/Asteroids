using System;

namespace Game.Input.Base
{
    public abstract class BaseInputModel : IInputModel
    {
        public event Action<float> OnUpdate;
        
        public bool IsShipShooting { get; set; }
        public float ShipTurnDirection { get; set; }

        public virtual void Update(float deltaTime) => OnUpdate?.Invoke(deltaTime);
    }
}