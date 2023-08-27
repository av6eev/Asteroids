using System;
using Game.CameraUpdater;
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