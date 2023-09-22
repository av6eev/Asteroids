using Game.Entities.Asteroids;
using Game.Entities.Asteroids.Asteroid.Base;
using Global.Pulls.Base;

namespace Global.Pulls.Asteroids
{
    public interface IAsteroidsPullView : IPullView<IAsteroidView>
    {
        public AsteroidsTypes Type { get; }
    }
}