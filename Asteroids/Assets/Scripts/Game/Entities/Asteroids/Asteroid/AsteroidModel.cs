using System;
using Game.Entities.Base;
using Specifications.Asteroids;
using UnityEngine;
using Utilities;
using Utilities.Interfaces;
using Random = UnityEngine.Random;

namespace Game.Entities.Asteroids.Asteroid
{
    public class AsteroidModel : BaseEntity, IMovable, IUpdatable
    {
        public event Action<float> OnUpdate;
        public event Action OnDestroy;
        
        public AsteroidSpecification Specification { get; }
        public Vector3 Direction { get; }
        public Vector3 Position { get; private set; }
        public float Speed { get; private set; }

        public AsteroidModel(AsteroidSpecification specification, float speedShift, Vector3 position)
        {
            Specification = specification;
            Position = position;
            Health = specification.Health;
            Speed = specification.Speed * speedShift;
            Direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-2f, 0f));
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