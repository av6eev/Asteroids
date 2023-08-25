using System;
using UnityEngine;
using Utilities;

namespace Game.Ship.Move
{
    public class ShipMoveModel : IUpdatable
    {
        public event Action<float> OnUpdate;
        
        public float ShipSpeed { get; }
        public Vector3 Position { get; private set; }
        public Vector3 Direction { get; set; }

        public ShipMoveModel(float shipSpeed) => ShipSpeed = shipSpeed;

        public void Update(float deltaTime) => OnUpdate?.Invoke(deltaTime);

        public void SetPosition(Vector3 newPosition) => Position = newPosition;
    }
}