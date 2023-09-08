using System;
using UnityEngine;
using Utilities.Interfaces;

namespace Game.Entities.Ship.Rotate
{
    public class ShipRotateModel : IUpdatable
    {
        public event Action<float> OnUpdate;

        private float CurrentRotation { get; set; }
        
        public void Update(float deltaTime) => OnUpdate?.Invoke(deltaTime);

        public bool TryUpdateRotation(float rotation, out float currentRotation)
        {
            var sum = CurrentRotation + rotation;
            
            if (sum is > -45 and < 45)
            {
                CurrentRotation = sum;
             
                currentRotation = CurrentRotation;
                return true;
            }

            currentRotation = CurrentRotation;
            return false;
        }

        public void ResetRotation(Quaternion currentRotation) => CurrentRotation = currentRotation.z;
    }
}