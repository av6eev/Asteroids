using Game.Entities.Asteroids.Asteroid.Base;

namespace Global.Factories.Pulls.Asteroids.Base
{
    public abstract class BaseAsteroidsPullElementViewFactory
    {
        public abstract IAsteroidView GetSmall(GlobalEnvironment environment);
        public abstract IAsteroidView GetMedium(GlobalEnvironment environment);
        public abstract IAsteroidView GetBig(GlobalEnvironment environment);
        public abstract IAsteroidView GetFire(GlobalEnvironment environment);
    }
}