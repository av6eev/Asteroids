using System;
using UnityEngine;
using Utilities;

namespace Game.Ship.Shots.Shot
{
    public class ShotModel : IUpdatable
    {
        public event Action<float> OnUpdate;
        public Vector3 Position { get; set; }
        public float Speed { get; private set; }

        public ShotModel(Vector3 position, float speed)
        {
            Position = position;
            Speed = speed;
        }

        public void Update(float deltaTime)
        {
            OnUpdate?.Invoke(deltaTime);
        }
    }
}