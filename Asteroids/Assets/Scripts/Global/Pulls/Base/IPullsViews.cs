using Global.Pulls.Asteroids;
using Global.Pulls.Bullets;
using Global.Pulls.ParticleSystem.Hit;
using Global.Pulls.ParticleSystem.Hit.Base;

namespace Global.Pulls.Base
{
    public interface IPullsViews
    {
        IAsteroidsPullView SmallAsteroidsPullView { get; }
        IAsteroidsPullView MediumAsteroidsPullView { get; }
        IAsteroidsPullView BigAsteroidsPullView { get; }
        IAsteroidsPullView FireAsteroidsPullView { get; }
        IBulletsPullView BulletsPullView { get; }
        IHitsPullView HitsPullView { get; }
    }
}