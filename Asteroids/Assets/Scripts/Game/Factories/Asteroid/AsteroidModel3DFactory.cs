using Game.Entities.Asteroids.Asteroid;
using Game.Entities.Asteroids.Asteroid.Base;
using Game.Factories.Asteroid.Base;
using Specifications.Asteroids;
using Specifications.Asteroids.Base;

namespace Game.Factories.Asteroid
{
    public class AsteroidModel3DFactory : BaseAsteroidModelFactory
    {
        public override IAsteroidModel Create(IAsteroidModel baseModel) => new AsteroidModel3D(baseModel);
        public override IAsteroidModel Create(IAsteroidSpecification specification, float speedShift) => new AsteroidModel3D(specification, speedShift);
    }
}