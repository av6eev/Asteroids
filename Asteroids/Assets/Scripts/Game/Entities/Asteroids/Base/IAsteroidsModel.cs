using System;
using System.Collections.Generic;
using Game.Entities.Asteroids.Asteroid.Base;
using Specifications.Asteroids;
using Utilities.Interfaces;

namespace Game.Entities.Asteroids.Base
{
    public interface IAsteroidsModel : IUpdatable
    {
        event Action<IAsteroidModel, bool, bool> OnAsteroidDestroyed;
        
        Dictionary<AsteroidsTypes, AsteroidSpecification> Specifications { get; }
        Dictionary<IAsteroidModel, IAsteroidView> ActiveAsteroids { get; }
        float SpawnRate { get; }
        float SpeedShift { get; }
        
        Dictionary<IAsteroidModel, IAsteroidView> GetActiveAsteroids();
        void AddActiveAsteroid(IAsteroidModel model, IAsteroidView view3D);
        void RemoveActiveAsteroid(IAsteroidModel model);
        void ResetActiveAsteroids();
        void DestroyAsteroid(IAsteroidModel model, bool byBorder, bool byShip);
        IAsteroidView GetByKey(IAsteroidModel model);
        void UpdateModifiers(float spawnRateShift, float speedShift);
    }
}