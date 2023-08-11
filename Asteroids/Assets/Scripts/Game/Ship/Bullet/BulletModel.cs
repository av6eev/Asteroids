using System;
using UnityEngine;
using Utilities;

namespace Game.Ship.Shots
{
    public class BulletModel : IUpdatable
    {
        public event Action<float> OnUpdate;
        public Vector3 Position { get; set; }
        public float Speed { get; private set; }

        public BulletModel(Vector3 position, float speed)
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