using System;
using Utilities;

namespace Game.Ship.Rotate
{
    public class ShipRotateModel : IUpdatable
    {
        public event Action<float> OnUpdate;
        
        public void Update(float deltaTime)
        {
            OnUpdate?.Invoke(deltaTime);    
        }
    }
}