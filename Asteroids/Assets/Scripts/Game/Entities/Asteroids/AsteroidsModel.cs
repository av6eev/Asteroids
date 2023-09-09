using System;
using System.Collections.Generic;
using Game.Entities.Asteroids.Asteroid;
using Game.Entities.Asteroids.Asteroid.Base;
using Specifications.Asteroids;
using Utilities.Interfaces;

namespace Game.Entities.Asteroids
{
    public class AsteroidsModel : IUpdatable
    {
        public event Action<float> OnUpdate;
        public event Action<AsteroidModel, bool, bool> OnAsteroidDestroyed;
        public Dictionary<AsteroidsTypes, AsteroidSpecification> Specifications { get; }
        private Dictionary<AsteroidModel, BaseAsteroidView> ActiveAsteroids { get; set; } = new();
        public float SpawnRate { get; private set; } = .5f;
        public float SpeedShift { get; private set; }

        public AsteroidsModel(Dictionary<AsteroidsTypes, AsteroidSpecification> specifications) => Specifications = specifications;

        public void Update(float deltaTime) => OnUpdate?.Invoke(deltaTime);

        public Dictionary<AsteroidModel, BaseAsteroidView> GetActiveAsteroids() => ActiveAsteroids;

        public void AddActiveAsteroid(AsteroidModel model, BaseAsteroidView view3D) => ActiveAsteroids.Add(model, view3D);

        public void RemoveActiveAsteroid(AsteroidModel model) => ActiveAsteroids.Remove(model);

        public void ResetActiveAsteroids(Dictionary<AsteroidModel, BaseAsteroidView> newList) => ActiveAsteroids = newList;

        public void DestroyAsteroid(AsteroidModel model, bool byBorder, bool byShip) => OnAsteroidDestroyed?.Invoke(model, byBorder, byShip);
        
        public BaseAsteroidView GetByKey(AsteroidModel model) => ActiveAsteroids[model];

        public void UpdateModifiers(float spawnRateShift, float speedShift)
        {
            SpeedShift = speedShift;
            SpawnRate *= spawnRateShift;
        }
    }
}