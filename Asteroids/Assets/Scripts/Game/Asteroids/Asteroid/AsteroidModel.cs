using System;
using Specifications.Asteroids;
using UnityEngine;
using Utilities;
using Random = UnityEngine.Random;

namespace Game.Asteroids.Asteroid
{
    public class AsteroidModel : IUpdatable
    {
        public event Action<float> OnUpdate;
        public event Action<BaseAsteroidView> OnViewChanged;
        
        public AsteroidSpecification Specification { get; }
        public Vector3 Position { get; set; }
        public Vector3 Direction { get; }
        public int Health { get; set; }
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

        public void ChangeView(BaseAsteroidView newView) => OnViewChanged?.Invoke(newView);

        public void ResetPosition(Vector3 newPosition) => Position = newPosition;
    }
}