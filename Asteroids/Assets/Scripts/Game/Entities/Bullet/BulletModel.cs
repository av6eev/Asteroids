using System;
using Game.Entities.Base;
using UnityEngine;
using Utilities.Interfaces;

namespace Game.Entities.Bullet
{
    public class BulletModel : IEntity, IMovable, IUpdatable
    {
        public event Action<float> OnUpdate;
        public event Action OnDestroy;
        
        public Vector3 Position { get; private set; }
        public int Damage { get; }
        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; }

        public BulletModel(Vector3 position, int health, int damage)
        {
            Position = position;
            CurrentHealth = health;
            MaxHealth = health;
            Damage = damage;
        }

        public void Update(float deltaTime) => OnUpdate?.Invoke(deltaTime);

        public void UpdatePosition(Vector3 newPosition) => Position = newPosition;
        
        public Vector3 GetPosition() => Position;

        public void ApplyDamage(int damage)
        {
            CurrentHealth -= damage;
            
            if (CurrentHealth <= 0)
            {
                OnDestroy?.Invoke();
            }
        }
    }
}