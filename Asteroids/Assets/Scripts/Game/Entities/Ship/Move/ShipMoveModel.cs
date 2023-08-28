using System;
using Game.Entities.Base;
using UnityEngine;
using Utilities;

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

        public Vector3 RecalculatePosition(CameraDimensionsTypes dimension)
        {
            var newPosition = dimension switch
            {
                CameraDimensionsTypes.TwoD => new Vector3(Position.x, Position.z, 0),
                CameraDimensionsTypes.ThreeD => new Vector3(Position.x, 0, Position.y),
                _ => Vector3.zero
            };

            Position = newPosition;
            return Position;
        }
    }
}