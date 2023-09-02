using System;
using Utilities.Interfaces;

namespace Game.Input
{
    public class InputModel : IUpdatable
    {
        public bool IsShipShooting { get; set; }
        public float ShipTurnDirection { get; set; }
        public event Action<float> OnUpdate;
        
        public void Update(float deltaTime) => OnUpdate?.Invoke(deltaTime);
    }
}