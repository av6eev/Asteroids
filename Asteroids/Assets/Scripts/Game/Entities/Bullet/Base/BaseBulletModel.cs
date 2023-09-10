using System;
using UnityEngine;
using Utilities.Game;

namespace Game.Entities.Bullet.Base
{
    public abstract class BaseBulletModel : IBulletModel
    {
        public event Action<float> OnUpdate;
        public event Action OnDestroy;
        
        public Vector3 Position { get; private set; }
        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; }
        public int Damage { get; }

        protected BaseBulletModel(Vector3 position, int health, int damage)
        {
            Position = position;
            CurrentHealth = health;
            MaxHealth = health;
            Damage = damage;
        }

        public virtual Vector3 GetPosition() => Position;

        public virtual void UpdatePosition(Vector3 newPosition) => Position = newPosition;

        public virtual void Update(float deltaTime) => OnUpdate?.Invoke(deltaTime);

        public abstract bool CheckIntersects(GameZoneLimits zoneLimits);

        public virtual void ApplyDamage(int damage)
        {
            CurrentHealth -= damage;
            
            if (CurrentHealth <= 0)
            {
                OnDestroy?.Invoke();
            }
        }
    }
}