using System;
using System.Collections.Generic;
using Game.Asteroids.Asteroid;
using Specifications.Asteroids;
using Utilities;

namespace Game.Asteroids
{
    public class AsteroidsModel : IUpdatable
    {
        public event Action<float> OnUpdate;
        public Dictionary<AsteroidsTypes, AsteroidSpecification> Specification { get; }
        public float SpawnRate { get; } = .2f;

        public AsteroidsModel(Dictionary<AsteroidsTypes, AsteroidSpecification> specification)
        {
            Specification = specification;
        }

        public void Update(float deltaTime)
        {
            OnUpdate?.Invoke(deltaTime);
        }
    }
}