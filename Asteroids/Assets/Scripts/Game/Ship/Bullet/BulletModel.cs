using System;
using UnityEngine;
using Utilities;

namespace Game.Ship.Bullet
{
    public class BulletModel : IUpdatable
    {
        public event Action<float> OnUpdate;
        public event Action OnDestroyed;
        
        public Vector3 Position { get; set; }
        public float Speed { get; private set; }
        public int Health { get; set; }
        public int Damage { get; }
        public bool IsEffectEnabled { get; set; }

        public BulletModel(Vector3 position, float speed, int health, int damage)
        {
            Position = position;
            Speed = speed;
            Health = health;
            Damage = damage;
        }

        public void Update(float deltaTime) => OnUpdate?.Invoke(deltaTime);

        public void DisableHitEffect()
        {
            OnDestroyed?.Invoke();
        }
    }
}