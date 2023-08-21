using System;
using UnityEngine;
using Utilities;

namespace Game.Ship.Bullet
{
    public class BulletModel : IUpdatable
    {
        public event Action<float> OnUpdate;
        
        public Vector3 Position { get; set; }
        public int Health { get; set; }
        public int Damage { get; }

        public BulletModel(Vector3 position, int health, int damage)
        {
            Position = position;
            Health = health;
            Damage = damage;
        }

        public void Update(float deltaTime) => OnUpdate?.Invoke(deltaTime);
    }
}