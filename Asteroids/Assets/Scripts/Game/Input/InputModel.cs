using System;
using Utilities;

namespace Game.Input
{
    public class InputModel : IUpdatable
    {
        public bool IsShipRotating { get; set; }
        public bool IsShipShooting { get; set; }
        public float ShipRotateDirection { get; set; }
        public event Action<float> OnUpdate;
        
        public void Update(float deltaTime) => OnUpdate?.Invoke(deltaTime);
    }
}