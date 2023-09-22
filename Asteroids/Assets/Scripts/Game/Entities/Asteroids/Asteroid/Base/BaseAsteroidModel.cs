using System;
using Specifications.Asteroids;
using Specifications.Asteroids.Base;
using UnityEngine;
using Utilities.Game;
using Random = UnityEngine.Random;

namespace Game.Entities.Asteroids.Asteroid.Base
{
    public abstract class BaseAsteroidModel : IAsteroidModel
    {
        public event Action<float> OnUpdate;
        public event Action OnDestroy;
        
        public IAsteroidSpecification Specification { get; }
        public Vector3 Direction { get; }
        public Vector3 Position { get; protected set; }
        public float Speed { get; }

        public int CurrentHealth { get; private set; }

        public int MaxHealth { get; }

        protected BaseAsteroidModel(IAsteroidSpecification specification, float speedShift)
        {
            Specification = specification;
            CurrentHealth = specification.Health;
            MaxHealth = specification.Health;
            Speed = specification.Speed * speedShift;
            Direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-2f, 0f));
        }

        protected BaseAsteroidModel(IAsteroidModel asteroidModel)
        {
            Specification = asteroidModel.Specification;
            Position = asteroidModel.Position;
            CurrentHealth = asteroidModel.CurrentHealth;
            MaxHealth = asteroidModel.MaxHealth;
            Speed = asteroidModel.Speed;
            Direction = asteroidModel.Direction;
        }

        public virtual Vector3 GetPosition() => Position;

        public virtual void UpdatePosition(Vector3 newPosition) => Position = newPosition;

        public void Update(float deltaTime) => OnUpdate?.Invoke(deltaTime);

        public virtual void ApplyDamage(int damage)
        {
            CurrentHealth -= damage;
            
            if (CurrentHealth <= 0)
            {
                OnDestroy?.Invoke();
            }
        }

        public abstract void SetPosition(float horizontal, float forward);
        public abstract Tuple<float, float> GetPositionWithOffset(float horizontal, float forward);

        public abstract bool CheckIntersects(GameZoneLimits limits);
    }
}