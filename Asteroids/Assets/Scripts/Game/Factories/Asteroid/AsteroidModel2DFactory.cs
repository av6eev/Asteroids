using Game.Entities.Asteroids.Asteroid;
using Game.Entities.Asteroids.Asteroid.Base;
using Game.Factories.Asteroid.Base;
using Specifications.Asteroids;

namespace Game.Factories.Asteroid
{
    public class AsteroidModel2DFactory : BaseAsteroidModelFactory
    {
        public override IAsteroidModel Create(IAsteroidModel baseModel) => new AsteroidModel2D(baseModel);
        public override IAsteroidModel Create(AsteroidSpecification specification, float speedShift) => new AsteroidModel2D(specification, speedShift);
    }
}