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
        public AsteroidSpecification Specification { get; }
        public Vector3 Position { get; set; }
        public Vector3 Direction { get; }
        public int Health { get; set; }

        public AsteroidModel(AsteroidSpecification specification, Vector3 position)
        {
            Specification = specification;
            Position = position;
            Health = specification.Health;
            Direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        }

        public void Update(float deltaTime) => OnUpdate?.Invoke(deltaTime);
    }
}