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
        public event Action<AsteroidModel, bool> OnAsteroidDestroyed;
        public Dictionary<AsteroidsTypes, AsteroidSpecification> Specifications { get; }
        private readonly Dictionary<AsteroidModel, AsteroidView> _activeAsteroids = new();
        public static float SpawnRate => .5f;

        public AsteroidsModel(Dictionary<AsteroidsTypes, AsteroidSpecification> specifications)
        {
            Specifications = specifications;
        }

        public void Update(float deltaTime) => OnUpdate?.Invoke(deltaTime);

        public void DestroyAsteroid(AsteroidModel model, bool byBorder) => OnAsteroidDestroyed?.Invoke(model, byBorder);

        public Dictionary<AsteroidModel, AsteroidView> GetActiveAsteroids() => _activeAsteroids;

        public void AddActiveAsteroid(AsteroidModel model, AsteroidView view) => _activeAsteroids.Add(model, view);

        public void RemoveActiveAsteroid(AsteroidModel model) => _activeAsteroids.Remove(model);
        
        public AsteroidView GetByKey(AsteroidModel model) => _activeAsteroids[model];
    }
}