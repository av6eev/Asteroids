using Game.Entities.Bullet.Base;
using Global.Base;

namespace Global.Factories.Pulls.Bullets.Base
{
    public abstract class BaseBulletsPullElementViewFactory
    {
        public abstract IBulletView Get(IGlobalEnvironment environment);
    }
}