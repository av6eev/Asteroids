using System;
using Game.Entities.Base;
using Specifications.Asteroids;
using UnityEngine;
using Utilities.Interfaces;
using Random = UnityEngine.Random;

namespace Game.Entities.Asteroids.Asteroid
{
    public class AsteroidModel : IEntity, IMovable, IUpdatable
    {
        private int _health;
        public event Action<float> OnUpdate;
        public event Action OnDestroy;
        
        public AsteroidSpecification Specification { get; }
        public Vector3 Direction { get; }
        public Vector3 Position { get; private set; }
        public float Speed { get; private set; }
        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; }

        public AsteroidModel(AsteroidSpecification specification, float speedShift, Vector3 position)
        {
            Specification = specification;
            Position = position;
            CurrentHealth = specification.Health;
            MaxHealth = specification.Health;
            Speed = specification.Speed * speedShift;
            Direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-2f, 0f));
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