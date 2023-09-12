using Game.Entities.Asteroids.Asteroid.Base;
using Specifications.Asteroids;

namespace Game.Factories.Asteroid.Base
{
    public abstract class BaseAsteroidModelFactory
    {
        public abstract IAsteroidModel Create(IAsteroidModel baseModel);
        public abstract IAsteroidModel Create(AsteroidSpecification specification, float speedShift);
    }
}