using Game.Entities.Asteroids;
using Game.Entities.Asteroids.Asteroid.Base;
using Global.Base;
using Global.Factories.Pulls.Asteroids.Base;

namespace Global.Factories.Pulls.Asteroids
{
    public class AsteroidsPullElementView2DFactory : BaseAsteroidsPullElementViewFactory
    {
        public override IAsteroidView GetSmall(IGlobalEnvironment environment) => environment.Specifications.Asteroids[AsteroidsTypes.Small].AsteroidView2D;

        public override IAsteroidView GetMedium(IGlobalEnvironment environment) => environment.Specifications.Asteroids[AsteroidsTypes.Medium].AsteroidView2D;

        public override IAsteroidView GetBig(IGlobalEnvironment environment) => environment.Specifications.Asteroids[AsteroidsTypes.Big].AsteroidView2D;

        public override IAsteroidView GetFire(IGlobalEnvironment environment) => environment.Specifications.Asteroids[AsteroidsTypes.Fire].AsteroidView2D;
    }
}