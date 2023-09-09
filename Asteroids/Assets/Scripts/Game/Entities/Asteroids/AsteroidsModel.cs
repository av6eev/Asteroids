using System;
using System.Collections.Generic;
using Game.Entities.Asteroids.Asteroid.Base;
using Specifications.Asteroids;
using Utilities.Interfaces;

namespace Game.Entities.Asteroids
{
    public class AsteroidsModel : IUpdatable
    {
        public event Action<float> OnUpdate;
        public event Action<IAsteroidModel, bool, bool> OnAsteroidDestroyed;
        public Dictionary<AsteroidsTypes, AsteroidSpecification> Specifications { get; }
        private Dictionary<IAsteroidModel, BaseAsteroidView> ActiveAsteroids { get; set; } = new();
        public float SpawnRate { get; private set; } = .5f;
        public float SpeedShift { get; private set; }

        public AsteroidsModel(Dictionary<AsteroidsTypes, AsteroidSpecification> specifications) => Specifications = specifications;

        public void Update(float deltaTime) => OnUpdate?.Invoke(deltaTime);

        public Dictionary<IAsteroidModel, BaseAsteroidView> GetActiveAsteroids() => ActiveAsteroids;

        public void AddActiveAsteroid(IAsteroidModel model, BaseAsteroidView view3D) => ActiveAsteroids.Add(model, view3D);

        public void RemoveActiveAsteroid(IAsteroidModel model) => ActiveAsteroids.Remove(model);

        public void ResetActiveAsteroids() => ActiveAsteroids.Clear();

        public void DestroyAsteroid(IAsteroidModel model, bool byBorder, bool byShip) => OnAsteroidDestroyed?.Invoke(model, byBorder, byShip);
        
        public BaseAsteroidView GetByKey(IAsteroidModel model) => ActiveAsteroids[model];

        public void UpdateModifiers(float spawnRateShift, float speedShift)
        {
            SpeedShift = speedShift;
            SpawnRate *= spawnRateShift;
        }
    }
}