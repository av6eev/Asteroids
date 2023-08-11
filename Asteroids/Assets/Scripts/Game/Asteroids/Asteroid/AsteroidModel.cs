using System;
using Specifications.Asteroids;
using UnityEngine;
using Utilities;
using Random = Unity.Mathematics.Random;

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
            var random = new Random((uint)DateTime.Now.Second);

            Specification = specification;
            Position = position;
            Health = specification.Health;
            Direction = new Vector3(random.NextFloat(-1f, 1f), 0, random.NextFloat(-1f, 1f));
        }

        public void Update(float deltaTime)
        {
            OnUpdate?.Invoke(deltaTime);
        }
    }
}