using System;
using System.Collections.Generic;
using System.Linq;
using Game.Asteroids.Asteroid;
using Specifications.Asteroids;
using Utilities;

namespace Game.Asteroids
{
    public class AsteroidsModel : IUpdatable
    {
        public event Action<float> OnUpdate;
        public event Action<AsteroidModel> OnAsteroidDestroyed;
        public Dictionary<AsteroidsTypes, AsteroidSpecification> Specification { get; }
        private readonly Dictionary<AsteroidModel, AsteroidView> _activeAsteroids = new();
        public float SpawnRate { get; } = .5f;

        public AsteroidsModel(Dictionary<AsteroidsTypes, AsteroidSpecification> specification)
        {
            Specification = specification;
        }

        public void Update(float deltaTime)
        {
            OnUpdate?.Invoke(deltaTime);
        }

        public void DestroyAsteroid(AsteroidModel model)
        {
            OnAsteroidDestroyed?.Invoke(model);
        }

        public void AddActiveAsteroid(AsteroidModel model, AsteroidView view)
        {
            _activeAsteroids.Add(model, view);
        }
        
        public Dictionary<AsteroidModel, AsteroidView> GetActiveAsteroids()
        {
            return _activeAsteroids;
        }

        public AsteroidModel GetByValue(AsteroidView view)
        {
            if (!_activeAsteroids.ContainsValue(view)) return null;

            return _activeAsteroids.Where(asteroid => asteroid.Value == view).Select(asteroid => asteroid.Key).FirstOrDefault();
        }
    }
}