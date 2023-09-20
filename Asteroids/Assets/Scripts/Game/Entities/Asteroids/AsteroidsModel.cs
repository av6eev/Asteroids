using System;
using System.Collections.Generic;
using Game.Entities.Asteroids.Asteroid.Base;
using Game.Entities.Asteroids.Base;
using Specifications.Asteroids;

namespace Game.Entities.Asteroids
{
    public class AsteroidsModel : IAsteroidsModel
    {
        public event Action<float> OnUpdate;
        public event Action<IAsteroidModel, bool, bool> OnAsteroidDestroyed;
        public Dictionary<AsteroidsTypes, AsteroidSpecification> Specifications { get; }
        public Dictionary<IAsteroidModel, IAsteroidView> ActiveAsteroids { get; } = new();
        public float SpawnRate { get; private set; } = .5f;
        public float SpeedShift { get; private set; }

        public AsteroidsModel(Dictionary<AsteroidsTypes, AsteroidSpecification> specifications) => Specifications = specifications;

        public void Update(float deltaTime) => OnUpdate?.Invoke(deltaTime);

        public Dictionary<IAsteroidModel, IAsteroidView> GetActiveAsteroids() => ActiveAsteroids;

        public void AddActiveAsteroid(IAsteroidModel model, IAsteroidView view3D) => ActiveAsteroids.Add(model, view3D);

        public void RemoveActiveAsteroid(IAsteroidModel model) => ActiveAsteroids.Remove(model);

        public void ResetActiveAsteroids() => ActiveAsteroids.Clear();

        public void DestroyAsteroid(IAsteroidModel model, bool byBorder, bool byShip) => OnAsteroidDestroyed?.Invoke(model, byBorder, byShip);
        
        public IAsteroidView GetByKey(IAsteroidModel model) => ActiveAsteroids[model];

        public void UpdateModifiers(float spawnRateShift, float speedShift)
        {
            SpeedShift = speedShift;
            SpawnRate *= spawnRateShift;
        }
    }
}