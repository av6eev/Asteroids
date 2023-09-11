using System;

namespace Game.Input
{
    public class InputModel : IInputModel
    {
        public event Action<float> OnUpdate;
        
        public bool IsShipShooting { get; set; }
        public float ShipTurnDirection { get; set; }

        public void Update(float deltaTime) => OnUpdate?.Invoke(deltaTime);
    }
}