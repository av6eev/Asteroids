using System;
using Game.Entities.Base;
using UnityEngine;
using Utilities;

namespace Game.Entities.Bullet
{
    public class BulletModel : BaseEntity, IMovable, IUpdatable
    {
        public event Action<float> OnUpdate;
        public event Action OnDestroy;
        
        public Vector3 Position { get; private set; }
        public int Damage { get; }

        public BulletModel(Vector3 position, int health, int damage)
        {
            Position = position;
            Health = health;
            Damage = damage;
        }

        public void Update(float deltaTime) => OnUpdate?.Invoke(deltaTime);

        public void UpdatePosition(Vector3 newPosition) => Position = newPosition;

        public override void ApplyDamage(int damage)
        {
            Health -= damage;
            
            if (Health <= 0)
            {
                OnDestroy?.Invoke();
            }
        }
    }
}