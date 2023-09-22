using Game.Entities.Asteroids;
using Game.Entities.Asteroids.Asteroid.Base;
using Global.Factories.Pulls.Asteroids.Base;

namespace Global.Factories.Pulls.Asteroids
{
    public class AsteroidsPullElementView2DFactory : BaseAsteroidsPullElementViewFactory
    {
        public override IAsteroidView GetSmall(GlobalEnvironment environment) => environment.Specifications.Asteroids[AsteroidsTypes.Small].Prefab2D;

        public override IAsteroidView GetMedium(GlobalEnvironment environment) => environment.Specifications.Asteroids[AsteroidsTypes.Medium].Prefab2D;

        public override IAsteroidView GetBig(GlobalEnvironment environment) => environment.Specifications.Asteroids[AsteroidsTypes.Big].Prefab2D;

        public override IAsteroidView GetFire(GlobalEnvironment environment) => environment.Specifications.Asteroids[AsteroidsTypes.Fire].Prefab2D;
    }
}