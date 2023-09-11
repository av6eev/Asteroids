using System;
using System.Collections.Generic;
using Game.Entities.Asteroids.Asteroid.Base;
using Specifications.Asteroids;
using Utilities.Interfaces;

namespace Game.Entities.Asteroids
{
    public interface IAsteroidsModel : IUpdatable
    {
        event Action<IAsteroidModel, bool, bool> OnAsteroidDestroyed;
        
        Dictionary<AsteroidsTypes, AsteroidSpecification> Specifications { get; }
        Dictionary<IAsteroidModel, BaseAsteroidView> ActiveAsteroids { get; }
        float SpawnRate { get; }
        float SpeedShift { get; }
        
        Dictionary<IAsteroidModel, BaseAsteroidView> GetActiveAsteroids();
        void AddActiveAsteroid(IAsteroidModel model, BaseAsteroidView view3D);
        void RemoveActiveAsteroid(IAsteroidModel model);
        void ResetActiveAsteroids();
        void DestroyAsteroid(IAsteroidModel model, bool byBorder, bool byShip);
        BaseAsteroidView GetByKey(IAsteroidModel model);
        void UpdateModifiers(float spawnRateShift, float speedShift);
    }
}