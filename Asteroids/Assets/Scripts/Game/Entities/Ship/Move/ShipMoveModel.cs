using System;
using Game.Entities.Base;
using UnityEngine;
using Utilities.Interfaces;

namespace Game.Entities.Ship.Move
{
    public class ShipMoveModel : IMovable, IUpdatable
    {
        public event Action<float> OnUpdate;
        
        public float ShipSpeed { get; }
        public Vector3 Position { get; private set; }

        public ShipMoveModel(float shipSpeed) => ShipSpeed = shipSpeed;

        public void Update(float deltaTime) => OnUpdate?.Invoke(deltaTime);

        public void UpdatePosition(Vector3 newPosition) => Position = newPosition;
    }
}