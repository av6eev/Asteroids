using Game.Entities.Asteroids.Asteroid.Base;
using Global.Base;

namespace Global.Factories.Pulls.Asteroids.Base
{
    public abstract class BaseAsteroidsPullElementViewFactory
    {
        public abstract IAsteroidView GetSmall(IGlobalEnvironment environment);
        public abstract IAsteroidView GetMedium(IGlobalEnvironment environment);
        public abstract IAsteroidView GetBig(IGlobalEnvironment environment);
        public abstract IAsteroidView GetFire(IGlobalEnvironment environment);
    }
}